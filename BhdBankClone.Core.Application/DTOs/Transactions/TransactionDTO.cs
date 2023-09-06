

namespace BhdBankClone.Core.Application.DTOs.Transactions
{
  public class TransactionDTO
  {
    public int Id { get; set; }
    public int TransactionTypeId { get; set; }
    public int ClientId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionTime { get; set; }

    public int? SourceAccountId { get; set; }

    public int? SourceCreditCardId { get; set; }

    public int? SourceDebitCardId { get; set; }

    public int? DestinationCreditCardId { get; set; }

    public int? DestinationAccountId { get; set; }

    public int? DestinationLoanId { get; set; }

  }
}
