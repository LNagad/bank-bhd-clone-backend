using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class CreditCard : AuditableBaseEntity
{
    public decimal CreditLimit { get; set; }

    public decimal CurrentBalance { get; set; }

    public decimal CreditCardDebt { get; set; }

    public required string CardNumber { get; set; }

    public DateTime CardExpiryDate { get; set; }

    public required string CardCvv { get; set; }

    public required bool IsActive { get; set; }

    public required bool IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public required int ClientId { get; set; }

    public  Client? Client { get; set; } 
    public  Product? Product { get; set; }

    public  ICollection<BankTransaction>? Transactions { get; set; } 
}
