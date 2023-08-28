using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class BhdContext : DbContext
{

  public BhdContext(DbContextOptions<BhdContext> options) : base(options) { }

  public virtual DbSet<Account> Accounts { get; set; }

  public virtual DbSet<AccountType> AccountTypes { get; set; }

  public virtual DbSet<Client> Clients { get; set; }

  public virtual DbSet<ClientStatus> ClientStatuses { get; set; }

  public virtual DbSet<ClientType> ClientsTypes { get; set; }

  public virtual DbSet<CreditCard> CreditCards { get; set; }

  public virtual DbSet<DebitCard> DebitCards { get; set; }

  public virtual DbSet<Loan> Loans { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  public virtual DbSet<ProductType> ProductTypes { get; set; }

  public virtual DbSet<Transaction> Transactions { get; set; }

  public virtual DbSet<TransactionType> TransactionTypes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //modelBuilder.ApplyConfiguration(new AccountConfig());
    //modelBuilder.ApplyConfiguration(new TransactionConfig());
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
