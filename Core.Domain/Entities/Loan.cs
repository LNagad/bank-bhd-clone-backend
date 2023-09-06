using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Loan : AuditableBaseEntity
{

  public double LoanAmount { get; set; }

  public double LoanBalance { get; set; }

  public bool IsActive { get; set; }

  public int ProductId { get; set; }

  public int ClientId { get; set; }

  public int AccountId { get; set; }

  public int? SourceTransactionId { get; set; }

  public  Client? Client { get; set; }

  public  Product? Product { get; set; }

  public  Account? Account { get; set; }

  public BankTransaction? SourceTransaction { get; set; }

  public ICollection<BankTransaction>? DestinationTransactions { get; set; }

}
