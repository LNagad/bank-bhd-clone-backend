using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class AccountType : AuditableBaseEntity
{

    public string? Description { get; set; }

    public virtual ICollection<Account>? Accounts { get; set; }
}
