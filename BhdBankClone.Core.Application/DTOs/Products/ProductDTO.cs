
namespace BhdBankClone.Core.Application.DTOs.Products
{
  public class ProductDTO
  {

    public int? ProductTypeId { get; set; }

    public int? ClientId { get; set; }

    public bool? IsAccount { get; set; }

    public bool? IsLoan { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsDebitCard { get; set; }

    public int? AccountId { get; set; }

    public int? LoanId { get; set; }

    public int? CreditCardId { get; set; }

    public int? DebitCardId { get; set; }
  }
}
