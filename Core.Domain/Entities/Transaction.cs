using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain;

public class Transaction : AuditableBaseEntity
{

    public int? TransactionTypeId { get; set; }

    public int? ClientId { get; set; }

    public DateTime? TransactionTime { get; set; }

    public decimal? Amount { get; set; }

    public int? SourceAccountId { get; set; }

    public int? SourceCreditCardId { get; set; }

    public int? SourceDebitCardId { get; set; }

    public int? DestinationCreditCardId { get; set; }

    public int? DestinationAccountId { get; set; }

    public int? DestinationLoanId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Account? DestinationAccount { get; set; }

    public virtual CreditCard? DestinationCreditCard { get; set; }

    public virtual Loan? DestinationLoan { get; set; }

    public virtual Account? SourceAccount { get; set; }

    public virtual CreditCard? SourceCreditCard { get; set; }

    public virtual DebitCard? SourceDebitCard { get; set; }

    public virtual TransactionType? TransactionType { get; set; }
}
