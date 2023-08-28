using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class ClientStatus : AuditableBaseEntity
{
    public string? Description { get; set; }
}
