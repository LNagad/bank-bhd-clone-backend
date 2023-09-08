using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;

namespace BhdBankClone.Core.Application.DTOs.Loans
{
  public class LoanDTO
  {
    public int Id { get; set; }
    public double? LoanAmount { get; set; }

    public bool? IsActive { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public int? AccountId { get; set; }

    public ClientDTO? Client { get; set; }

    //public ProductDTO? Product { get; set; }

    public BankAccountDTO? Account { get; set; }

    public TransactionDTO? SourceTransaction { get; set; } = null;

    public ICollection<TransactionDTO>? DestinationTransactions { get; set; }
  }
}
