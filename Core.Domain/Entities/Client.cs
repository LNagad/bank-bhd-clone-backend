using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Client : AuditableBaseEntity
{
  public string? UserId { get; set; }

  public int? ClientsTypeId { get; set; }

  public string? IdentityCard { get; set; }

  public bool? IsActive { get; set; }

  public int? StatusId { get; set; }

  public ClientType? ClientType { get; set; }
  public ClientStatus? ClientStatus { get; set; }
  public ICollection<Account>? Accounts { get; set; }
  public ICollection<CreditCard>? CreditCards { get; set; }
  public ICollection<DebitCard>? DebitCards { get; set; }
  public ICollection<Loan>? Loans { get; set; }
  public ICollection<Product>? Products { get; set; }
}
