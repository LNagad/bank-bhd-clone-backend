using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init_with_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client_statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ClientTypeId = table.Column<int>(type: "int", nullable: true),
                    IdentityCard = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clients_client_statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "client_statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_clients_clients_types_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "clients_types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "credit_cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: true),
                    CurrentBalance = table.Column<decimal>(type: "money", nullable: true),
                    CreditCardDebt = table.Column<decimal>(type: "money", nullable: true),
                    CardNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    CardExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CardCvv = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_credit_cards_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    AccountTypeId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    DebitCardId = table.Column<int>(type: "int", nullable: true),
                    current_balance = table.Column<decimal>(type: "money", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accounts_account_types_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "account_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_accounts_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "debit_cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    CardExpiryDate = table.Column<DateTime>(type: "date", nullable: true),
                    CardCvv = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_debit_cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_debit_cards_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_debit_cards_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    IsAccount = table.Column<bool>(type: "bit", nullable: true),
                    IsLoan = table.Column<bool>(type: "bit", nullable: true),
                    IsCreditCard = table.Column<bool>(type: "bit", nullable: true),
                    IsDebitCard = table.Column<bool>(type: "bit", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    DebitCardId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_credit_cards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_debit_cards_DebitCardId",
                        column: x => x.DebitCardId,
                        principalTable: "debit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "loans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_products_product_types_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "product_types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    TransactionTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: true),
                    SourceAccountId = table.Column<int>(type: "int", nullable: true),
                    SourceCreditCardId = table.Column<int>(type: "int", nullable: true),
                    SourceDebitCardId = table.Column<int>(type: "int", nullable: true),
                    DestinationCreditCardId = table.Column<int>(type: "int", nullable: true),
                    DestinationAccountId = table.Column<int>(type: "int", nullable: true),
                    DestinationLoanId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    DebitCardId = table.Column<int>(type: "int", nullable: true),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_DestinationCreditCardId",
                        column: x => x.DestinationCreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_SourceCreditCardId",
                        column: x => x.SourceCreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_debit_cards_DebitCardId",
                        column: x => x.DebitCardId,
                        principalTable: "debit_cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_debit_cards_SourceDebitCardId",
                        column: x => x.SourceDebitCardId,
                        principalTable: "debit_cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_loans_DestinationLoanId",
                        column: x => x.DestinationLoanId,
                        principalTable: "loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "loans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_transactions_transaction_types_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "transaction_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CUENTA_AHORROS", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CUENTA_AHORROS_EMPRESARIAL", null, null }
                });

            migrationBuilder.InsertData(
                table: "clients_types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CLIENTE_TIPO_PERSONAL", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CLIENTE_TIPO_EMPRESARIAL", null, null }
                });

            migrationBuilder.InsertData(
                table: "product_types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CUENTA_AHORROS", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "CUENTA_AHORROS_EMPRESARIAL", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TARJETA_DEBITO", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TARJETA_CREDITO", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PRESTAMO", null, null }
                });

            migrationBuilder.InsertData(
                table: "transaction_types",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TRANSFERENCIA", null, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RETIRO", null, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DEPOSITO", null, null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PAGO_TARJETA_CREDITO", null, null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PAGO_PRESTAMO", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "account_types_index_12",
                table: "account_types",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "UQ__account___489B0D977287E385",
                table: "account_types",
                column: "Description",
                unique: true,
                filter: "[Description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "accounts_index_2",
                table: "accounts",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "accounts_index_3",
                table: "accounts",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_AccountTypeId",
                table: "accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_ClientId",
                table: "accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_DebitCardId",
                table: "accounts",
                column: "DebitCardId",
                unique: true,
                filter: "[DebitCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "client_statuses_index_11",
                table: "client_statuses",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "clients_index_0",
                table: "clients",
                column: "IdentityCard");

            migrationBuilder.CreateIndex(
                name: "clients_index_1",
                table: "clients",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_clients_ClientTypeId",
                table: "clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_StatusId",
                table: "clients",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "UQ__clients__4943C3B41C2804E7",
                table: "clients",
                column: "IdentityCard",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "clients_types_index_13",
                table: "clients_types",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "UQ__clients___489B0D974E8DBA8C",
                table: "clients_types",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_4",
                table: "credit_cards",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_5",
                table: "credit_cards",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_6",
                table: "credit_cards",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_credit_cards_ClientId",
                table: "credit_cards",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_7",
                table: "debit_cards",
                column: "CardNumber");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_8",
                table: "debit_cards",
                column: "IsPrimary");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_9",
                table: "debit_cards",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_debit_cards_AccountId",
                table: "debit_cards",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_debit_cards_ClientId",
                table: "debit_cards",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId",
                table: "loans",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "loans_index_10",
                table: "loans",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_products_AccountId",
                table: "products",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_ClientId",
                table: "products",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CreditCardId",
                table: "products",
                column: "CreditCardId",
                unique: true,
                filter: "[CreditCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_DebitCardId",
                table: "products",
                column: "DebitCardId",
                unique: true,
                filter: "[DebitCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_LoanId",
                table: "products",
                column: "LoanId",
                unique: true,
                filter: "[LoanId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "transaction_types_index_21",
                table: "transaction_types",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_ClientId",
                table: "transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_CreditCardId",
                table: "transactions",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_DebitCardId",
                table: "transactions",
                column: "DebitCardId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_LoanId",
                table: "transactions",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TransactionTypeId",
                table: "transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_14",
                table: "transactions",
                column: "TransactionTime");

            migrationBuilder.CreateIndex(
                name: "transactions_index_15",
                table: "transactions",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_16",
                table: "transactions",
                column: "SourceCreditCardId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_17",
                table: "transactions",
                column: "SourceDebitCardId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_18",
                table: "transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_19",
                table: "transactions",
                column: "DestinationCreditCardId");

            migrationBuilder.CreateIndex(
                name: "transactions_index_20",
                table: "transactions",
                column: "DestinationLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId",
                table: "accounts",
                column: "DebitCardId",
                principalTable: "debit_cards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_account_types_AccountTypeId",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_clients_ClientId",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_debit_cards_clients_ClientId",
                table: "debit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId",
                table: "accounts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "product_types");

            migrationBuilder.DropTable(
                name: "credit_cards");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "transaction_types");

            migrationBuilder.DropTable(
                name: "account_types");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "client_statuses");

            migrationBuilder.DropTable(
                name: "clients_types");

            migrationBuilder.DropTable(
                name: "debit_cards");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
