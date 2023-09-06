﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BhdBankClone.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230906214603_loans_transaction_source-transaction_added")]
    partial class loans_transaction_sourcetransaction_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BhdBankClone.Core.Domain.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<int?>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CurrentBalance")
                        .HasColumnType("money")
                        .HasColumnName("current_balance");

                    b.Property<int?>("DebitCardId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool?>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DebitCardId")
                        .IsUnique()
                        .HasFilter("[DebitCardId] IS NOT NULL");

                    b.HasIndex(new[] { "AccountNumber" }, "accounts_index_2");

                    b.HasIndex(new[] { "IsPrimary" }, "accounts_index_3");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Description" }, "UQ__account___489B0D977287E385")
                        .IsUnique()
                        .HasFilter("[Description] IS NOT NULL");

                    b.HasIndex(new[] { "Description" }, "account_types_index_12");

                    b.ToTable("account_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CUENTA_AHORROS"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CUENTA_AHORROS_EMPRESARIAL"
                        });
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.BankTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DebitCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationCreditCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationLoanId")
                        .HasColumnType("int");

                    b.Property<int?>("LoanId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceCreditCardId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceDebitCardId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceLoanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionTime")
                        .HasColumnType("datetime");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("DebitCardId");

                    b.HasIndex("LoanId");

                    b.HasIndex("SourceLoanId")
                        .IsUnique()
                        .HasFilter("[SourceLoanId] IS NOT NULL");

                    b.HasIndex("TransactionTypeId");

                    b.HasIndex(new[] { "TransactionTime" }, "transactions_index_14");

                    b.HasIndex(new[] { "SourceAccountId" }, "transactions_index_15");

                    b.HasIndex(new[] { "SourceCreditCardId" }, "transactions_index_16");

                    b.HasIndex(new[] { "SourceDebitCardId" }, "transactions_index_17");

                    b.HasIndex(new[] { "DestinationAccountId" }, "transactions_index_18");

                    b.HasIndex(new[] { "DestinationCreditCardId" }, "transactions_index_19");

                    b.HasIndex(new[] { "DestinationLoanId" }, "transactions_index_20");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "IdentityCard" }, "UQ__clients__4943C3B41C2804E7")
                        .IsUnique();

                    b.HasIndex(new[] { "IdentityCard" }, "clients_index_0");

                    b.HasIndex(new[] { "IsActive" }, "clients_index_1");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.ClientStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique()
                        .HasDatabaseName("client_statuses_index_11");

                    b.ToTable("client_statuses", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.ClientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Description" }, "UQ__clients___489B0D974E8DBA8C")
                        .IsUnique();

                    b.HasIndex(new[] { "Description" }, "clients_types_index_13");

                    b.ToTable("clients_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CLIENTE_TIPO_PERSONAL"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CLIENTE_TIPO_EMPRESARIAL"
                        });
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardCvv")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("CardExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CreditCardDebt")
                        .HasColumnType("money");

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("money");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnType("money");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex(new[] { "CardNumber" }, "credit_cards_index_4");

                    b.HasIndex(new[] { "IsPrimary" }, "credit_cards_index_5");

                    b.HasIndex(new[] { "IsActive" }, "credit_cards_index_6");

                    b.ToTable("credit_cards", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.DebitCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CardCvv")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime?>("CardExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool?>("IsPrimary")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("ClientId");

                    b.HasIndex(new[] { "CardNumber" }, "debit_cards_index_7");

                    b.HasIndex(new[] { "IsPrimary" }, "debit_cards_index_8");

                    b.HasIndex(new[] { "IsActive" }, "debit_cards_index_9");

                    b.ToTable("debit_cards", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("money");

                    b.Property<double>("LoanBalance")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceTransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClientId");

                    b.HasIndex(new[] { "IsActive" }, "loans_index_10");

                    b.ToTable("loans", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditCardId")
                        .HasColumnType("int");

                    b.Property<int?>("DebitCardId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAccount")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCreditCard")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDebitCard")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLoan")
                        .HasColumnType("bit");

                    b.Property<int?>("LoanId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreditCardId")
                        .IsUnique()
                        .HasFilter("[CreditCardId] IS NOT NULL");

                    b.HasIndex("DebitCardId")
                        .IsUnique()
                        .HasFilter("[DebitCardId] IS NOT NULL");

                    b.HasIndex("LoanId")
                        .IsUnique()
                        .HasFilter("[LoanId] IS NOT NULL");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("product_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CUENTA_AHORROS"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "CUENTA_AHORROS_EMPRESARIAL"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "TARJETA_DEBITO"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "TARJETA_CREDITO"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PRESTAMO"
                        });
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Description" }, "transaction_types_index_21");

                    b.ToTable("transaction_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "TRANSFERENCIA"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "RETIRO"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "DEPOSITO"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PAGO_TARJETA_CREDITO"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PAGO_PRESTAMO"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "PRESTAMO"
                        });
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Account", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.AccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId");

                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId");

                    b.HasOne("BhdBankClone.Core.Domain.DebitCard", "DebitCard")
                        .WithOne()
                        .HasForeignKey("BhdBankClone.Core.Domain.Account", "DebitCardId");

                    b.Navigation("AccountType");

                    b.Navigation("Client");

                    b.Navigation("DebitCard");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.BankTransaction", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");

                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BhdBankClone.Core.Domain.CreditCard", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CreditCardId");

                    b.HasOne("BhdBankClone.Core.Domain.DebitCard", null)
                        .WithMany("Transactions")
                        .HasForeignKey("DebitCardId");

                    b.HasOne("BhdBankClone.Core.Domain.Account", "DestinationAccount")
                        .WithMany()
                        .HasForeignKey("DestinationAccountId");

                    b.HasOne("BhdBankClone.Core.Domain.CreditCard", "DestinationCreditCard")
                        .WithMany()
                        .HasForeignKey("DestinationCreditCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.Loan", "DestinationLoan")
                        .WithMany()
                        .HasForeignKey("DestinationLoanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.Loan", null)
                        .WithMany("DestinationTransactions")
                        .HasForeignKey("LoanId");

                    b.HasOne("BhdBankClone.Core.Domain.Account", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.CreditCard", "SourceCreditCard")
                        .WithMany()
                        .HasForeignKey("SourceCreditCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.DebitCard", "SourceDebitCard")
                        .WithMany()
                        .HasForeignKey("SourceDebitCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.Loan", "SourceLoan")
                        .WithOne("SourceTransaction")
                        .HasForeignKey("BhdBankClone.Core.Domain.BankTransaction", "SourceLoanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BhdBankClone.Core.Domain.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("DestinationAccount");

                    b.Navigation("DestinationCreditCard");

                    b.Navigation("DestinationLoan");

                    b.Navigation("SourceAccount");

                    b.Navigation("SourceCreditCard");

                    b.Navigation("SourceDebitCard");

                    b.Navigation("SourceLoan");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Client", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId");

                    b.HasOne("BhdBankClone.Core.Domain.ClientStatus", "ClientStatus")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("ClientStatus");

                    b.Navigation("ClientType");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.CreditCard", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany("CreditCards")
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.DebitCard", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.Account", "Account")
                        .WithOne()
                        .HasForeignKey("BhdBankClone.Core.Domain.DebitCard", "AccountId");

                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany("DebitCards")
                        .HasForeignKey("ClientId");

                    b.Navigation("Account");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Loan", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.Account", "Account")
                        .WithMany("Loans")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany("Loans")
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Product", b =>
                {
                    b.HasOne("BhdBankClone.Core.Domain.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("AccountId");

                    b.HasOne("BhdBankClone.Core.Domain.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.HasOne("BhdBankClone.Core.Domain.CreditCard", "CreditCard")
                        .WithOne("Product")
                        .HasForeignKey("BhdBankClone.Core.Domain.Product", "CreditCardId");

                    b.HasOne("BhdBankClone.Core.Domain.DebitCard", "DebitCard")
                        .WithOne("Product")
                        .HasForeignKey("BhdBankClone.Core.Domain.Product", "DebitCardId");

                    b.HasOne("BhdBankClone.Core.Domain.Loan", "Loan")
                        .WithOne("Product")
                        .HasForeignKey("BhdBankClone.Core.Domain.Product", "LoanId");

                    b.HasOne("BhdBankClone.Core.Domain.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Client");

                    b.Navigation("CreditCard");

                    b.Navigation("DebitCard");

                    b.Navigation("Loan");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Account", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Products");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.AccountType", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Client", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("CreditCards");

                    b.Navigation("DebitCards");

                    b.Navigation("Loans");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.ClientType", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.CreditCard", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.DebitCard", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.Loan", b =>
                {
                    b.Navigation("DestinationTransactions");

                    b.Navigation("Product");

                    b.Navigation("SourceTransaction");
                });

            modelBuilder.Entity("BhdBankClone.Core.Domain.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
