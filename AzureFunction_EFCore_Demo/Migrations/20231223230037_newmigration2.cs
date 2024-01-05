using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureFunction_EFCore_Demo.Migrations
{
    public partial class newmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_Stocks_StockStockID",
                table: "StockTransactions");

            migrationBuilder.RenameColumn(
                name: "StockStockID",
                table: "StockTransactions",
                newName: "StockID");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactions_StockStockID",
                table: "StockTransactions",
                newName: "IX_StockTransactions_StockID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_Stocks_StockID",
                table: "StockTransactions",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_Stocks_StockID",
                table: "StockTransactions");

            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "StockTransactions",
                newName: "StockStockID");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransactions_StockID",
                table: "StockTransactions",
                newName: "IX_StockTransactions_StockStockID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_Stocks_StockStockID",
                table: "StockTransactions",
                column: "StockStockID",
                principalTable: "Stocks",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
