using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAI.Data;

namespace WAI.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CurrentMonthRecord> GetCurrentMonthRecord()
        {
            List<CurrentMonthRecord> list = new List<CurrentMonthRecord>();

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                DateTime beginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);

                var query = from c in ctx.BudgetCategories
                            select new CurrentMonthRecord
                            {
                                category = c.Name,
                                value = c.Transactions.Where(x => x.TransactionDate >= beginDate && x.TransactionDate < endDate).Sum(x => x.Amount)
                            };

                list = query.ToList();

                return list;
            }
        }
    }

    public class CurrentMonthRecord
    {
        public string category { get; set; }
        public decimal value { get; set; }
    }
}
