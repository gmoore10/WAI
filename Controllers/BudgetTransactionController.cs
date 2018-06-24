using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAI.Data;

namespace WAI.Controllers
{
    [Route("api/[controller]")]
    public class BudgetTransactionController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BudgetTransactionDataModel> Get()
        {
            List<BudgetTransactionDataModel> list = new List<BudgetTransactionDataModel>();

            ApplicationDbContext ctx = new ApplicationDbContext();

            var query = from t in ctx.BudgetTransactions
                        select t;

            list = query.ToList();

            return list;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] BudgetTransactionDataModel newTrans)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                try
                {
                    var trans = newTrans;
                    trans.AddedBy = 1;
                    trans.DateAdded = DateTime.UtcNow;
                    trans.BudgetCategoryId = newTrans.BudgetCategoryId;
                    trans.Amount = newTrans.Amount;
                    trans.Name = newTrans.Name;

                    ctx.BudgetTransactions.Add(trans);
                    ctx.SaveChanges();

                    return Ok(trans);
                }
                catch (Exception e)
                {
                    return StatusCode(500, newTrans);
                }
            }
        }

        [HttpPut]
        public IActionResult EditTransaction([FromBody] BudgetTransactionDataModel updatedTrans)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                BudgetTransactionDataModel item = ctx.BudgetTransactions.FirstOrDefault(x => x.Id == updatedTrans.Id);
                try
                {
                    var trans = updatedTrans;
                    item.LastModifiedBy = 1;
                    item.DateLastModified = DateTime.UtcNow;
                    item.Amount = trans.Amount;
                    item.Name = trans.Name;
                    item.BudgetCategoryId = trans.BudgetCategoryId;

                    ctx.BudgetTransactions.Update(item);
                    ctx.SaveChanges();

                    return Ok(item);
                }
                catch (Exception e)
                {
                    return StatusCode(500, item);
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class BudgetTransaction {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal CategoryId { get; set; }
        public decimal Amount { get; set; }
        public decimal BudgetRemaining { get; set; }
    }
}
