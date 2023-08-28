using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class CreditCard : AuditableBaseEntity
{
    public decimal? CreditLimit { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? CreditCardDebt { get; set; }

    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; } 
    public virtual Product? Product { get; set; }

    public virtual ICollection<Transaction>? TransactionDestinationCreditCards { get; set; } 

    public virtual ICollection<Transaction>? TransactionSourceCreditCards { get; set; }
}
