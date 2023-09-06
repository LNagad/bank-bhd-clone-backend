using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class loans_transaction_sourcetransaction_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceLoanId",
                table: "transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceTransactionId",
                table: "loans",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "transaction_types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PRESTAMO", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_SourceLoanId",
                table: "transactions",
                column: "SourceLoanId",
                unique: true,
                filter: "[SourceLoanId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_loans_SourceLoanId",
                table: "transactions",
                column: "SourceLoanId",
                principalTable: "loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_loans_SourceLoanId",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_SourceLoanId",
                table: "transactions");

            migrationBuilder.DeleteData(
                table: "transaction_types",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "SourceLoanId",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "SourceTransactionId",
                table: "loans");
        }
    }
}
