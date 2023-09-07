using BhdBankClone.Core.Domain.Common;
using System.Transactions;

namespace BhdBankClone.Core.Domain;

public class Account: AuditableBaseEntity
{

  public string? AccountNumber { get; set; }

  public bool? IsActive { get; set; }

  public bool? IsPrimary { get; set; }

  public int? AccountTypeId { get; set; }

  public int? ClientId { get; set; }

  public int? ProductId { get; set; }

  public int? DebitCardId { get; set; }

  public decimal? CurrentBalance { get; set; }

  public  AccountType? AccountType { get; set; }

  public  Client? Client { get; set; }

  public  DebitCard? DebitCard { get; set; }

  public ICollection<Product>? Products { get; set; } // can have debit cards, can have loans

  //public ICollection<string>? Transactions { get; set; }

  public ICollection<Loan>? Loans { get; set; }

  //Propiedades de navegación para las transacciones con esta cuenta como destino
  public ICollection<BankTransaction>? TransactionsAsDestination { get; set; }

  // Propiedades de navegación para las transacciones con esta cuenta como fuente
  public ICollection<BankTransaction>? TransactionsAsSource { get; set; }

}
