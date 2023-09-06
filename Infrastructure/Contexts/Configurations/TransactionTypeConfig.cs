using BhdBankClone.Core.Application.Enums.BankSeeds;
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

      entity.HasIndex(e => e.Description, "transaction_types_index_21");

      entity.Property(e => e.Description)
              .HasMaxLength(100)
              .IsUnicode(false);

      entity.HasMany(transaction => transaction.Transactions)
        .WithOne(transaction => transaction.TransactionType)
        .HasForeignKey(transaction => transaction.TransactionTypeId);

      // Disabling auto include for navigation properties
      entity.Navigation(transactionType => transactionType.Transactions).AutoInclude(false);

      // Adding data to the table
      entity.HasData(
        new TransactionType() 
        { 
          Id = (int)ETransactions.TRANSFERENCIA, 
          Description = ETransactions.TRANSFERENCIA.ToString() 
        },
        new TransactionType()
        { 
          Id = (int)ETransactions.RETIRO, 
          Description = ETransactions.RETIRO.ToString() 
        },
        new TransactionType()
        { 
          Id = (int)ETransactions.DEPOSITO, 
          Description = ETransactions.DEPOSITO.ToString() 
        },
        new TransactionType()
        { 
          Id = (int)ETransactions.PAGO_TARJETA_CREDITO, 
          Description = ETransactions.PAGO_TARJETA_CREDITO.ToString() 
        },
        new TransactionType()
        { 
          Id = (int)ETransactions.PAGO_PRESTAMO, 
          Description = ETransactions.PAGO_PRESTAMO.ToString() 
        },
        new TransactionType()
        {
          Id = (int)ETransactions.PRESTAMO,
          Description = ETransactions.PRESTAMO.ToString()
        }
      );
    }
  }
}
