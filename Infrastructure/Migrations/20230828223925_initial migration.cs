using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    clients_type_id = table.Column<int>(type: "int", nullable: false),
                    identity_card = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    ClientTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                    table.ForeignKey(
                        name: "FK_clients_client_statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "client_statuses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_clients_clients_types_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "clients_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_clients_clients_types_clients_type_id",
                        column: x => x.clients_type_id,
                        principalTable: "clients_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    account_number = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    isPrimary = table.Column<bool>(type: "bit", nullable: true),
                    account_type_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    DebitCardId = table.Column<int>(type: "int", nullable: true),
                    current_balance = table.Column<decimal>(type: "money", nullable: true),
                    AccountTypeId1 = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    DebitCardId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_accounts_account_types_AccountTypeId1",
                        column: x => x.AccountTypeId1,
                        principalTable: "account_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_accounts_account_types_account_type_id",
                        column: x => x.account_type_id,
                        principalTable: "account_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_accounts_clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_accounts_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "credit_cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    credit_limit = table.Column<decimal>(type: "money", nullable: true),
                    current_balance = table.Column<decimal>(type: "money", nullable: true),
                    credit_card_debt = table.Column<decimal>(type: "money", nullable: true),
                    card_number = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    card_expiry_date = table.Column<DateTime>(type: "date", nullable: true),
                    card_cvv = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    isPrimary = table.Column<bool>(type: "bit", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_credit_cards_clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_credit_cards_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "debit_cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    card_number = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    card_expiry_date = table.Column<DateTime>(type: "date", nullable: true),
                    card_cvv = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    isPrimary = table.Column<bool>(type: "bit", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_debit_cards", x => x.id);
                    table.ForeignKey(
                        name: "FK_debit_cards_clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_debit_cards_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    loan_amount = table.Column<decimal>(type: "money", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                    table.ForeignKey(
                        name: "FK_loans_clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_loans_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    product_type_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    isAccount = table.Column<bool>(type: "bit", nullable: true),
                    isLoan = table.Column<bool>(type: "bit", nullable: true),
                    isCreditCard = table.Column<bool>(type: "bit", nullable: true),
                    isDebitCard = table.Column<bool>(type: "bit", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: true),
                    loan_id = table.Column<int>(type: "int", nullable: true),
                    credit_card_id = table.Column<int>(type: "int", nullable: true),
                    debit_card_id = table.Column<int>(type: "int", nullable: true),
                    AccountId1 = table.Column<int>(type: "int", nullable: true),
                    LoanId1 = table.Column<int>(type: "int", nullable: true),
                    CreditCardId1 = table.Column<int>(type: "int", nullable: true),
                    DebitCardId1 = table.Column<int>(type: "int", nullable: true),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_accounts_AccountId1",
                        column: x => x.AccountId1,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_credit_cards_CreditCardId1",
                        column: x => x.CreditCardId1,
                        principalTable: "credit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_debit_cards_DebitCardId1",
                        column: x => x.DebitCardId1,
                        principalTable: "debit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_loans_LoanId1",
                        column: x => x.LoanId1,
                        principalTable: "loans",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_products_product_types_product_type_id",
                        column: x => x.product_type_id,
                        principalTable: "product_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    transaction_type_id = table.Column<int>(type: "int", nullable: true),
                    client_id = table.Column<int>(type: "int", nullable: true),
                    transaction_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    amount = table.Column<decimal>(type: "money", nullable: true),
                    source_account_id = table.Column<int>(type: "int", nullable: true),
                    source_credit_card_id = table.Column<int>(type: "int", nullable: true),
                    source_debit_card_id = table.Column<int>(type: "int", nullable: true),
                    destination_credit_card_id = table.Column<int>(type: "int", nullable: true),
                    destination_account_id = table.Column<int>(type: "int", nullable: true),
                    destination_loan_id = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    DebitCardId = table.Column<int>(type: "int", nullable: true),
                    LoanId = table.Column<int>(type: "int", nullable: true),
                    TransactionTypeId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_transactions_accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_accounts_destination_account_id",
                        column: x => x.destination_account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_accounts_source_account_id",
                        column: x => x.source_account_id,
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "credit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_destination_credit_card_id",
                        column: x => x.destination_credit_card_id,
                        principalTable: "credit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_credit_cards_source_credit_card_id",
                        column: x => x.source_credit_card_id,
                        principalTable: "credit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_debit_cards_DebitCardId",
                        column: x => x.DebitCardId,
                        principalTable: "debit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_debit_cards_source_debit_card_id",
                        column: x => x.source_debit_card_id,
                        principalTable: "debit_cards",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "loans",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_loans_destination_loan_id",
                        column: x => x.destination_loan_id,
                        principalTable: "loans",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_transaction_types_TransactionTypeId1",
                        column: x => x.TransactionTypeId1,
                        principalTable: "transaction_types",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_transactions_transaction_types_transaction_type_id",
                        column: x => x.transaction_type_id,
                        principalTable: "transaction_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "account_types_index_12",
                table: "account_types",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "UQ__account___489B0D977287E385",
                table: "account_types",
                column: "description",
                unique: true,
                filter: "[description] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "accounts_index_2",
                table: "accounts",
                column: "account_number");

            migrationBuilder.CreateIndex(
                name: "accounts_index_3",
                table: "accounts",
                column: "isPrimary");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_account_type_id",
                table: "accounts",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_AccountTypeId1",
                table: "accounts",
                column: "AccountTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_client_id",
                table: "accounts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_ClientId1",
                table: "accounts",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_DebitCardId",
                table: "accounts",
                column: "DebitCardId",
                unique: true,
                filter: "[DebitCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_DebitCardId1",
                table: "accounts",
                column: "DebitCardId1",
                unique: true,
                filter: "[DebitCardId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_ProductId",
                table: "accounts",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "client_statuses_index_11",
                table: "client_statuses",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "clients_index_0",
                table: "clients",
                column: "identity_card");

            migrationBuilder.CreateIndex(
                name: "clients_index_1",
                table: "clients",
                column: "isActive");

            migrationBuilder.CreateIndex(
                name: "IX_clients_clients_type_id",
                table: "clients",
                column: "clients_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_clients_ClientTypeId",
                table: "clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_clients_status_id",
                table: "clients",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__clients__4943C3B41C2804E7",
                table: "clients",
                column: "identity_card",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "clients_types_index_13",
                table: "clients_types",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "UQ__clients___489B0D974E8DBA8C",
                table: "clients_types",
                column: "description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_4",
                table: "credit_cards",
                column: "card_number");

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_5",
                table: "credit_cards",
                column: "isPrimary");

            migrationBuilder.CreateIndex(
                name: "credit_cards_index_6",
                table: "credit_cards",
                column: "isActive");

            migrationBuilder.CreateIndex(
                name: "IX_credit_cards_client_id",
                table: "credit_cards",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_credit_cards_ClientId1",
                table: "credit_cards",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_credit_cards_product_id",
                table: "credit_cards",
                column: "product_id",
                unique: true,
                filter: "[product_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_7",
                table: "debit_cards",
                column: "card_number");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_8",
                table: "debit_cards",
                column: "isPrimary");

            migrationBuilder.CreateIndex(
                name: "debit_cards_index_9",
                table: "debit_cards",
                column: "isActive");

            migrationBuilder.CreateIndex(
                name: "IX_debit_cards_client_id",
                table: "debit_cards",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_debit_cards_ClientId1",
                table: "debit_cards",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_debit_cards_product_id",
                table: "debit_cards",
                column: "product_id",
                unique: true,
                filter: "[product_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_loans_client_id",
                table: "loans",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_loans_ClientId1",
                table: "loans",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_loans_product_id",
                table: "loans",
                column: "product_id",
                unique: true,
                filter: "[product_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "loans_index_10",
                table: "loans",
                column: "isActive");

            migrationBuilder.CreateIndex(
                name: "IX_products_AccountId1",
                table: "products",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_client_id",
                table: "products",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_ClientId1",
                table: "products",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_CreditCardId1",
                table: "products",
                column: "CreditCardId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_DebitCardId1",
                table: "products",
                column: "DebitCardId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_LoanId1",
                table: "products",
                column: "LoanId1");

            migrationBuilder.CreateIndex(
                name: "IX_products_product_type_id",
                table: "products",
                column: "product_type_id");

            migrationBuilder.CreateIndex(
                name: "transaction_types_index_21",
                table: "transaction_types",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_client_id",
                table: "transactions",
                column: "client_id");

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
                name: "IX_transactions_transaction_type_id",
                table: "transactions",
                column: "transaction_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TransactionTypeId1",
                table: "transactions",
                column: "TransactionTypeId1");

            migrationBuilder.CreateIndex(
                name: "transactions_index_14",
                table: "transactions",
                column: "transaction_time");

            migrationBuilder.CreateIndex(
                name: "transactions_index_15",
                table: "transactions",
                column: "source_account_id");

            migrationBuilder.CreateIndex(
                name: "transactions_index_16",
                table: "transactions",
                column: "source_credit_card_id");

            migrationBuilder.CreateIndex(
                name: "transactions_index_17",
                table: "transactions",
                column: "source_debit_card_id");

            migrationBuilder.CreateIndex(
                name: "transactions_index_18",
                table: "transactions",
                column: "destination_account_id");

            migrationBuilder.CreateIndex(
                name: "transactions_index_19",
                table: "transactions",
                column: "destination_credit_card_id");

            migrationBuilder.CreateIndex(
                name: "transactions_index_20",
                table: "transactions",
                column: "destination_loan_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId",
                table: "accounts",
                column: "DebitCardId",
                principalTable: "debit_cards",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId1",
                table: "accounts",
                column: "DebitCardId1",
                principalTable: "debit_cards",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_products_ProductId",
                table: "accounts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_credit_cards_products_product_id",
                table: "credit_cards",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_debit_cards_products_product_id",
                table: "debit_cards",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_loans_products_product_id",
                table: "loans",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_account_types_AccountTypeId1",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_account_types_account_type_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_clients_ClientId1",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_clients_client_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_cards_clients_ClientId1",
                table: "credit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_cards_clients_client_id",
                table: "credit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_debit_cards_clients_ClientId1",
                table: "debit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_debit_cards_clients_client_id",
                table: "debit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_clients_ClientId1",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_clients_client_id",
                table: "loans");

            migrationBuilder.DropForeignKey(
                name: "FK_products_clients_ClientId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_clients_client_id",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_debit_cards_DebitCardId1",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_products_debit_cards_DebitCardId1",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_products_ProductId",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_credit_cards_products_product_id",
                table: "credit_cards");

            migrationBuilder.DropForeignKey(
                name: "FK_loans_products_product_id",
                table: "loans");

            migrationBuilder.DropTable(
                name: "transactions");

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
                name: "products");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "credit_cards");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "product_types");
        }
    }
}
