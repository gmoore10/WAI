using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WAI.Data
{
    /// <summary>
    /// The database model for our application
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        #region Public Properties

        public DbSet<BudgetCategoryDataModel> BudgetCategories { get; set; }
        public DbSet<BudgetTransactionDataModel> BudgetTransactions { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=45.32.223.115;Database=DollarsAndSense;User Id=sa;Password=test12**;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BudgetCategoryDataModel>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.BudgetCategory)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BudgetTransactionDataModel>()
                .Property(x => x.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<BudgetCategoryDataModel>()
                .Property(x => x.DateAdded)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<BudgetCategoryDataModel>().HasData(
                new { Id = 1, Name = "Mortgage", Budgeted = 950.00m, AddedBy = 1, DateAdded = DateTime.UtcNow },
                new { Id = 2, Name = "Auto Fuel", Budgeted = 100.00m, AddedBy = 1, DateAdded = DateTime.UtcNow }
            );

            modelBuilder.Entity<BudgetTransactionDataModel>().HasData(
                new { Id = 1, Name = "Publix Trip", AddedBy = 1, TransactionDate = new DateTime(2018, 4, 6), BudgetCategoryId = 1, Amount = 182.56m, DateAdded = DateTime.UtcNow },
                new { Id = 2, Name = "Weekend Party", AddedBy = 1, TransactionDate = new DateTime(2018, 4, 9), BudgetCategoryId = 1, Amount = 441.22m, DateAdded = DateTime.UtcNow },
                new { Id = 3, Name = "Weekend Party 2", AddedBy = 1, TransactionDate = new DateTime(2018, 4, 9), BudgetCategoryId = 1, Amount = 25.00m, DateAdded = DateTime.UtcNow }
            );
        }
    }
}
