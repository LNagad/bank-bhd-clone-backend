﻿

using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.CreditCards;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.DTOs.Transactions
{
  public class FavoriteTransactionDTO
  {
    public int Id { get; set; }
    public required int TransactionTypeId { get; set; }
    public required int ClientId { get; set; }
    public decimal Amount { get; set; }

    public int? SourceAccountId { get; set; }

    public int? SourceCreditCardId { get; set; }

    public int? SourceDebitCardId { get; set; }

    public int? DestinationCreditCardId { get; set; }

    public int? DestinationAccountId { get; set; }

    public int? DestinationLoanId { get; set; }

    public ClientDTO? Client { get; set; }

    public BankAccountDTO? SourceAccount { get; set; }

    public CreditCardDTO? SourceCreditCard { get; set; }

    public DebitCardDTO? SourceDebitCard { get; set; }

    public Account? DestinationAccount { get; set; }

    public BankAccountDTO? DestinationCreditCard { get; set; }

    public LoanDTO? DestinationLoan { get; set; }

    public string? TransactionType { get; set; }
  }
}
