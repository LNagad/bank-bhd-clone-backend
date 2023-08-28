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

      entity.Property(e => e.Id)
          .ValueGeneratedNever()
          .HasColumnName("id");

      entity.Property(e => e.Description)
          .HasMaxLength(1)
          .IsUnicode(false)
          .HasColumnName("description");

      entity.HasMany<Account>()
        .WithOne(account => account.AccountType)
        .HasForeignKey(account => account.AccountTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull);
    }
  }
}
