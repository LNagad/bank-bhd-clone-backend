using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class favorite_transaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SourceAccountId = table.Column<int>(type: "int", nullable: true),
                    SourceCreditCardId = table.Column<int>(type: "int", nullable: true),
                    SourceDebitCardId = table.Column<int>(type: "int", nullable: true),
                    DestinationCreditCardId = table.Column<int>(type: "int", nullable: true),
                    DestinationAccountId = table.Column<int>(type: "int", nullable: true),
                    DestinationLoanId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_credit_cards_DestinationCreditCardId",
                        column: x => x.DestinationCreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_credit_cards_SourceCreditCardId",
                        column: x => x.SourceCreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_debit_cards_SourceDebitCardId",
                        column: x => x.SourceDebitCardId,
                        principalTable: "debit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_loans_DestinationLoanId",
                        column: x => x.DestinationLoanId,
                        principalTable: "loans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteTransactions_transaction_types_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "transaction_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_ClientId",
                table: "FavoriteTransactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_DestinationAccountId",
                table: "FavoriteTransactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_DestinationCreditCardId",
                table: "FavoriteTransactions",
                column: "DestinationCreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_DestinationLoanId",
                table: "FavoriteTransactions",
                column: "DestinationLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_SourceAccountId",
                table: "FavoriteTransactions",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_SourceCreditCardId",
                table: "FavoriteTransactions",
                column: "SourceCreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_SourceDebitCardId",
                table: "FavoriteTransactions",
                column: "SourceDebitCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteTransactions_TransactionTypeId",
                table: "FavoriteTransactions",
                column: "TransactionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteTransactions");
        }
    }
}
