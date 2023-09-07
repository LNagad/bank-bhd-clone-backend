

namespace BhdBankClone.Core.Application.DTOs.Transactions
{
  public class FavoriteTransactionDTO
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
  }
}
