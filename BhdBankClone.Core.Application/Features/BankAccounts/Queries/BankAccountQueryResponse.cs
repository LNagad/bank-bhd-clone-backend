using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Queries
{
  public class BankAccountQueryResponse
  {
    public int Id { get; set; }
    public string? AccountNumber { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    public int? AccountTypeId { get; set; }

    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public int? DebitCardId { get; set; }

    public decimal? CurrentBalance { get; set; }

    public string? AccountType { get; set; }
    //public string? ClientType { get; set; }

    public ClientDTO? Client { get; set; }

    public DebitCardDTO? DebitCard { get; set; }

    public ICollection<ProductDTO>? Products { get; set; } // can have debit cards, can have loans

    public ICollection<TransactionDTO>? TransactionsAsDestination { get; set; }
    public ICollection<TransactionDTO>? TransactionsAsSource { get; set; }

    public ICollection<LoanDTO>? Loans { get; set; }
  }
}
