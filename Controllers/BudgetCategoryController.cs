using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
