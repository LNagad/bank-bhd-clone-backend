﻿using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public partial class TransactionType : AuditableBaseEntity
{
    public string? Description { get; set; }

    public virtual ICollection<Transaction>? Transactions { get; set; } 
}