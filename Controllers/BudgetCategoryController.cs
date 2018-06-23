using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WAI.Data;

namespace WAI.Controllers
{
    [Route("api/[controller]")]
    public class BudgetCategoryController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BudgetCategoryDataModel> Get()
        {
            List<BudgetCategoryDataModel> list = new List<BudgetCategoryDataModel>();

            ApplicationDbContext ctx = new ApplicationDbContext();

            DateTime earliestTransDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-3).Month, 1);
            DateTime latestTransactionDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            DateTime beginOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);

            var query = from c in ctx.BudgetCategories
                        select c;

            var query2 = from c in query
                         select new BudgetCategoryDataModel
                         {
                             Budgeted = c.Budgeted,
                             AvgSpend = c.Transactions.Where(x => x.TransactionDate >= earliestTransDate && x.TransactionDate < latestTransactionDate).Sum(x => x.Amount),
                             Id = c.Id,
                             Name = c.Name,
                             Remaining = c.Transactions.Where(x => x.TransactionDate >= beginOfMonth && x.TransactionDate < endOfMonth).Sum(x => x.Amount)
                        };

            list = query2.ToList();

            var list2 = new List<BudgetCategoryDataModel>();

            foreach(BudgetCategoryDataModel item in list)
            {
                if(item.AvgSpend > 0)
                {
                    item.AvgSpend = item.AvgSpend / 3;
                }
                if(item.Budgeted > 0)
                {
                    item.Remaining = item.Budgeted - item.Remaining;
                }

                list2.Add(item);
            }

            return list2;
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddCategory([FromBody] BudgetCategoryDataModel newCat)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                try
                {
                    var cat = newCat;
                    cat.AddedBy = 1;
                    cat.DateAdded = DateTime.UtcNow;
                    cat.Budgeted = newCat.Budgeted;
                    cat.Name = newCat.Name;

                    ctx.BudgetCategories.Add(cat);
                    ctx.SaveChanges();

                    return Ok(cat);
                }
                catch (Exception e)
                {
                    return StatusCode(500, newCat);
                }
            }
        }

        [HttpPut]
        public IActionResult EditCategory([FromBody] BudgetCategoryDataModel updatedCat)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                BudgetCategoryDataModel item = ctx.BudgetCategories.FirstOrDefault(x => x.Id == updatedCat.Id);
                try
                {
                    var cat = updatedCat;
                    item.LastModifiedBy = 1;
                    item.DateLastModified = DateTime.UtcNow;
                    item.Budgeted = cat.Budgeted;
                    item.Name = cat.Name;

                    ctx.BudgetCategories.Update(item);
                    ctx.SaveChanges();

                    return Ok(item);
                }
                catch (Exception e)
                {
                    return StatusCode(500, item);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                BudgetCategoryDataModel item = ctx.BudgetCategories.FirstOrDefault(x => x.Id == id);
                try
                {
                    ctx.BudgetCategories.Remove(item);
                    ctx.SaveChanges();

                    return Ok();
                }
                catch (Exception e)
                {
                    return StatusCode(500, item);
                }
            }
        }
    }
}
