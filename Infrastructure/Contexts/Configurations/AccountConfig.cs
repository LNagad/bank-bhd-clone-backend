using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class AccountConfig : IEntityTypeConfiguration<Account>
  {
    public void Configure(EntityTypeBuilder<Account> entity)
    {
      entity.HasKey(e => e.Id);

      entity.ToTable("accounts");

      entity.HasIndex(e => e.AccountNumber, "accounts_index_2");

      entity.HasIndex(e => e.IsPrimary, "accounts_index_3");

      entity.Property(e => e.DebitCardId)
          .ValueGeneratedNever()
          .HasColumnName("DebitCardId");

      entity.Property(e => e.AccountNumber)
          .HasMaxLength(9)
          .IsUnicode(false)
          .HasColumnName("account_number");

      entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

      entity.Property(e => e.ClientId).HasColumnName("client_id");

      entity.Property(e => e.CurrentBalance)
          .HasColumnType("money")
          .HasColumnName("current_balance");

      entity.Property(e => e.IsActive)
          .HasDefaultValueSql("((1))")
          .HasColumnName("isActive");

      entity.Property(e => e.IsPrimary).HasColumnName("isPrimary");

      entity.HasMany<Transaction>()
          .WithOne(transaction => transaction.DestinationAccount)
          .HasForeignKey(transaction => transaction.DestinationAccountId);

      entity.HasMany<Transaction>()
          .WithOne(transaction => transaction.SourceAccount)
          .HasForeignKey(transaction => transaction.SourceAccountId);

    }
  }
}
