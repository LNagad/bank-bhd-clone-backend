using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class DebitCard : AuditableBaseEntity
{
    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public int? AccountId { get; set; }

    public  Client? Client { get; set; }

    public  Product? Product { get; set; }

    public  Account? Account { get; set; }

    public  ICollection<BankTransaction>? TransactionSourceDebitCard { get; set; }
}
