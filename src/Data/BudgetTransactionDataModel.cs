using System;
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
        [Required]
        public string Name { get; set; }
        [Column(TypeName="Money")]
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public int BudgetCategoryId { get; set; }
        public BudgetCategoryDataModel BudgetCategory { get; set; }

    }
}
