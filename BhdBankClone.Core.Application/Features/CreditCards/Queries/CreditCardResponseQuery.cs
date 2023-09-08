using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class CreditCardResponseQuery
  {
    public int Id { get; set; }
    public decimal? CreditLimit { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? CreditCardDebt { get; set; }

    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public ClientDTO? Client { get; set; }
    public ProductDTO? Product { get; set; }

    public ICollection<TransactionDTO>? TransactionsAsDestination { get; set; }
    public ICollection<TransactionDTO>? TransactionsAsSource { get; set; }
  }
}
