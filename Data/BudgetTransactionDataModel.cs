using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAI
{
    /// <summary>
    /// Our Settings Database Table Model
    /// </summary>
    public partial class BudgetTransactionDataModel : TableExtensions
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [Column(TypeName="Money")]
        public decimal Budgeted { get; set; }
        [Column(TypeName="Money")]
        public decimal Remaining { get; set; }
        [NotMapped]
        public decimal AvgSpend { get; set; }

        public BudgetCategoryDataModel BudgetCategory { get; set; }

    }
}
