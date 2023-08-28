using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class ClientType : AuditableBaseEntity
{

  public string? Description { get; set; }

  public ICollection<Client>? Clients { get; set; }
}
