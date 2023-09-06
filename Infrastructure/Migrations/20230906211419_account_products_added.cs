using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class account_products_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_products_AccountId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_AccountId",
                table: "products",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_products_AccountId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_AccountId",
                table: "products",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");
        }
    }
}
