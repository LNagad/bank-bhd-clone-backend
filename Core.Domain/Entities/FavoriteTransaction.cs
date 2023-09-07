using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Domain
{
  public class FavoriteTransaction : AuditableBaseEntity
  {
    public required int TransactionTypeId { get; set; }
    public required int ClientId { get; set; }
    public decimal Amount { get; set; }

    public int? SourceAccountId { get; set; }

    public int? SourceCreditCardId { get; set; }

    public int? SourceDebitCardId { get; set; }

    public int? DestinationCreditCardId { get; set; }

    public int? DestinationAccountId { get; set; }

    public int? DestinationLoanId { get; set; }

    public Client? Client { get; set; }

    public Account? SourceAccount { get; set; }

    public CreditCard? SourceCreditCard { get; set; }

    public DebitCard? SourceDebitCard { get; set; }
    
    public Account? DestinationAccount { get; set; }

    public CreditCard? DestinationCreditCard { get; set; }

    public Loan? DestinationLoan { get; set; }

    public TransactionType? TransactionType { get; set; }
  }
}