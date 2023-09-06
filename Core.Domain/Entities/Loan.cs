using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Loan : AuditableBaseEntity
{

  public double? LoanAmount { get; set; }

  public double? LoanBalance { get; set; }

  public bool? IsActive { get; set; }

  public int? ProductId { get; set; }

  public int? ClientId { get; set; }

  public  Client? Client { get; set; }

  public  Product? Product { get; set; }

  public ICollection<BankTransaction>? TransactionSourceDebitCard { get; set; }

}
