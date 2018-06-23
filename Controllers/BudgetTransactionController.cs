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

    public class BudgetTransaction {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal CategoryId { get; set; }
        public decimal Amount { get; set; }
        public decimal BudgetRemaining { get; set; }
    }
}
