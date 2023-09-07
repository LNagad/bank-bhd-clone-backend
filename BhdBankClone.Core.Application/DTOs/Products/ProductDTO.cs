
using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.CreditCards;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.ProductTypes;

namespace BhdBankClone.Core.Application.DTOs.Products
{
  public class ProductDTO
  {
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public bool? IsAccount { get; set; }

    public bool? IsLoan { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsDebitCard { get; set; }

    public int? AccountId { get; set; }

    public int? LoanId { get; set; }

    public int? CreditCardId { get; set; }

    public int? DebitCardId { get; set; }

    public virtual ClientDTO? Client { get; set; }
    public virtual ProductTypeDTO? ProductType { get; set; }
    public virtual BankAccountDTO? Account { get; set; }
    public virtual LoanDTO? Loan { get; set; }
    public virtual CreditCardDTO? CreditCard { get; set; }
    public virtual DebitCardDTO? DebitCard { get; set; }
  }
}
