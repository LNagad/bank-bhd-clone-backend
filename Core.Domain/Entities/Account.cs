using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Account: AuditableBaseEntity
{

  public string? AccountNumber { get; set; }

  public bool? IsActive { get; set; }

  public bool? IsPrimary { get; set; }

  public int? AccountTypeId { get; set; }

  public int? ClientId { get; set; }

  public int? ProductId { get; set; }

  public int? DebitCardId { get; set; }

  public decimal? CurrentBalance { get; set; }

  public  AccountType? AccountType { get; set; }

  public  Client? Client { get; set; }

  public  Product? Product { get; set; }

  public  DebitCard? DebitCard { get; set; }

  public  ICollection<BankTransaction>? Transactions { get; set; }

}
