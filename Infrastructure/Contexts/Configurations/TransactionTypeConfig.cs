using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  internal class TransactionTypeConfig : IEntityTypeConfiguration<TransactionType>
  {
    public void Configure(EntityTypeBuilder<TransactionType> entity)
    {
      entity.ToTable("transaction_types");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Id)
              .ValueGeneratedNever()
              .HasColumnName("id");

      entity.HasIndex(e => e.Description, "transaction_types_index_21");

      entity.Property(e => e.Description)
              .HasMaxLength(1)
              .IsUnicode(false)
              .HasColumnName("description");

      entity.HasMany<Transaction>()
        .WithOne(transaction => transaction.TransactionType)
        .HasForeignKey(transaction => transaction.TransactionTypeId);
    }
  }
}
