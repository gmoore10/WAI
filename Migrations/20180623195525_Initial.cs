using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetCategories",
                columns: table => new
                {
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    ts = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Budgeted = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetTransactions",
                columns: table => new
                {
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<int>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    ts = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Budgeted = table.Column<decimal>(type: "Money", nullable: false),
                    Remaining = table.Column<decimal>(type: "Money", nullable: false),
                    BudgetCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetTransactions_BudgetCategories_BudgetCategoryId",
                        column: x => x.BudgetCategoryId,
                        principalTable: "BudgetCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "Id", "AddedBy", "Budgeted", "DateAdded", "DateLastModified", "LastModifiedBy", "Name", "ts" },
                values: new object[] { 1, 1, 950.00m, new DateTime(2018, 6, 23, 19, 55, 22, 727, DateTimeKind.Utc), null, null, "Mortgage", null });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "Id", "AddedBy", "Budgeted", "DateAdded", "DateLastModified", "LastModifiedBy", "Name", "ts" },
                values: new object[] { 2, 1, 100.00m, new DateTime(2018, 6, 23, 19, 55, 22, 727, DateTimeKind.Utc), null, null, "Auto Fuel", null });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetTransactions_BudgetCategoryId",
                table: "BudgetTransactions",
                column: "BudgetCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetTransactions");

            migrationBuilder.DropTable(
                name: "BudgetCategories");
        }
    }
}
