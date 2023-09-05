using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class AccountTypeConfig : IEntityTypeConfiguration<AccountType>
  {
    public void Configure(EntityTypeBuilder<AccountType> entity)
    {
      entity.HasKey(e => e.Id);

      entity.ToTable("account_types");

      entity.HasIndex(e => e.Description, "UQ__account___489B0D977287E385").IsUnique();

      entity.HasIndex(e => e.Description, "account_types_index_12");

      entity.Property(e => e.Description)
          .HasMaxLength(100)
          .IsUnicode(false);

      entity.HasMany(account => account.Accounts)
        .WithOne(account => account.AccountType)
        .HasForeignKey(account => account.AccountTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      // Adding data to the table
      entity.HasData(
        new AccountType() 
        { 
          Id = (int)Accounts.CUENTA_AHORROS, 
          Description = Accounts.CUENTA_AHORROS.ToString() 
        },
        new AccountType() 
        { 
          Id = (int)Accounts.CUENTA_AHORROS_EMPRESARIAL, 
          Description = Accounts.CUENTA_AHORROS_EMPRESARIAL.ToString() 
        }
      );
    }
  }
}
