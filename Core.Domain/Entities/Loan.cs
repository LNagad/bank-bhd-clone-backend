using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Loan : AuditableBaseEntity
{

  public double? LoanAmount { get; set; }

  public bool? IsActive { get; set; }

  public int? ProductId { get; set; }

  public int? ClientId { get; set; }

  public Client? Client { get; set; }

  public Product? Product { get; set; }

  public virtual ICollection<Transaction>? TransactionSourceDebitCard { get; set; }

}
