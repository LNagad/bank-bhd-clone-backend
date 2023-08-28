using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Product : AuditableBaseEntity
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

  public Client? Client { get; set; }
  public ProductType? ProductType { get; set; }
  public Account? Account { get; set; }
  public Loan? Loan { get; set; }
  public CreditCard? CreditCard { get; set; }
  public DebitCard? DebitCard { get; set; }
}
