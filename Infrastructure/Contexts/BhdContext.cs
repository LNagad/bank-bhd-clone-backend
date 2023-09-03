using BhdBankClone.Core.Domain;
using BhdBankClone.Infrastructure.Persistence.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Infrastructure.Persistence;

public class BhdContext : DbContext
{

  public BhdContext(DbContextOptions<BhdContext> options) : base(options) { }

  public DbSet<Account> Accounts { get; set; }

  public DbSet<AccountType> AccountTypes { get; set; }

  public DbSet<Client> Clients { get; set; }

  public DbSet<ClientStatus> ClientStatuses { get; set; }

  public DbSet<ClientType> ClientsTypes { get; set; }

  public DbSet<CreditCard> CreditCards { get; set; }

  public DbSet<DebitCard> DebitCards { get; set; }

  public DbSet<Loan> Loans { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<ProductType> ProductTypes { get; set; }

  public DbSet<Transaction> Transactions { get; set; }

  public DbSet<TransactionType> TransactionTypes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new TransactionConfig());
    modelBuilder.ApplyConfiguration(new AccountConfig());
    modelBuilder.ApplyConfiguration(new DebitCardConfig());
    modelBuilder.ApplyConfiguration(new CreditCardConfig());
    modelBuilder.ApplyConfiguration(new ClientConfig());
    modelBuilder.ApplyConfiguration(new ClientStatusConfig());
    modelBuilder.ApplyConfiguration(new ProductConfig());
    modelBuilder.ApplyConfiguration(new ProductTypeConfig());
    modelBuilder.ApplyConfiguration(new LoanConfig());
    modelBuilder.ApplyConfiguration(new TransactionTypeConfig());
    
    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
