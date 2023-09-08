using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class DebitCardResponseQuery
  {
    public int Id { get; set; }
    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public ClientDTO? Client { get; set; }
    public BankAccountDTO? Account { get; set; }
  }
}
