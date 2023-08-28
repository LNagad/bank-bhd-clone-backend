using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class ProductType : AuditableBaseEntity
{

    public string? Description { get; set; }
}
