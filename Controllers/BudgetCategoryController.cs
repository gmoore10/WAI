using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WAI.Controllers
{
    [Route("api/[controller]")]
    public class BudgetCategoryController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<BudgetCategory> Get()
        {
            /*
            {id: 1, name: "Mortgage", budgeted: 182.56, remaining: 117.44, avgspend: 150.41},
            {id: 2, name: "Auto Fuel", budgeted: 182.56, remaining: 117.44, avgspend: 150.41} */

            BudgetCategory bgt1 = new BudgetCategory() { Id = 1, Name = "Mortgage", Budgeted = 182.56m, Remaining = 117.44m, AvgSpend = 150.41m };
            BudgetCategory bgt2 = new BudgetCategory() { Id = 2, Name = "Auto Fuel", Budgeted = 150.56m, Remaining = 121.44m, AvgSpend = 150.42m };
            
            List<BudgetCategory> list = new List<BudgetCategory>();

            list.Add(bgt1);
            list.Add(bgt2);

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
    public class BudgetCategory {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal Budgeted { get; set; }
        public decimal Remaining { get; set; }
        public decimal AvgSpend { get; set; }
    }
}