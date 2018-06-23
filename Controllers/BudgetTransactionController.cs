using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WAI.Controllers
{
    [Route("api/[controller]")]
    public class BudgetTransactionController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BudgetTransaction> Get()
        {
            List<BudgetTransaction> list = new List<BudgetTransaction>();

            /*{ id: 1, name: "Publix Trip", date: "4/6/2018", category: 1, amount: 182.56, budgetRemaining: 117.44 },
        { id: 2, name: "Weekend Party", date: "4/9/2018", category: 2, amount: 441.22, budgetRemaining: -323.78 },
        { id: 3, name: "Weekend Party", date: "4/9/2018", category: 2, amount: 150.00, budgetRemaining: -473.78 } */

            BudgetTransaction trn1 = new BudgetTransaction() { Id = 1, Name = "Publix Trip", TransactionDate = new DateTime(2018, 4, 6), CategoryId = 1, Amount = 182.56m, BudgetRemaining = 117.44m };
            BudgetTransaction trn2 = new BudgetTransaction() { Id = 1, Name = "Weekend Party", TransactionDate = new DateTime(2018, 4, 9), CategoryId = 1, Amount = 441.22m, BudgetRemaining = -323.78m };
            BudgetTransaction trn3 = new BudgetTransaction() { Id = 1, Name = "Weekend Party 2", TransactionDate = new DateTime(2018, 4, 9), CategoryId = 2, Amount = 25.00m, BudgetRemaining = -348.78m };

            list.Add(trn1);
            list.Add(trn2);
            list.Add(trn3);

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