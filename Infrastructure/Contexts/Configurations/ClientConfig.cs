using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ClientConfig : IEntityTypeConfiguration<Client>
  {
    public void Configure(EntityTypeBuilder<Client> entity)
    {
      entity.ToTable("clients");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.IdentityCard)
            .HasMaxLength(11)
            .IsUnicode(false)
            .IsRequired();

      entity.Property(e => e.UserId)
        .HasColumnType("nvarchar(100)");

      entity.Property(e => e.IsActive)
            .HasDefaultValue(true);

      entity.HasIndex(e => e.IdentityCard, "UQ__clients__4943C3B41C2804E7").IsUnique();

      entity.HasIndex(e => e.IdentityCard, "clients_index_0");

      entity.HasIndex(e => e.IsActive, "clients_index_1");

      //entity.HasMany<Account>()
      //      .WithOne(account => account.Client)
      //      .HasForeignKey(account => account.ClientId);

      //entity.HasMany<CreditCard>()
      //      .WithOne(creditCard => creditCard.Client)
      //      .HasForeignKey(creditCard => creditCard.ClientId);

      //entity.HasMany<DebitCard>()
      //      .WithOne(debit => debit.Client)
      //      .HasForeignKey(debit => debit.ClientId);

      //entity.HasMany<Loan>()
      //      .WithOne(loan => loan.Client)
      //      .HasForeignKey(loan => loan.ClientId);

      //entity.HasMany<Product>()
      //      .WithOne(product => product.Client)
      //      .HasForeignKey(product => product.ClientId);

      //entity.HasMany<Transaction>()
      //      .WithOne(tran => tran.Client)
      //      .HasForeignKey(tran => tran.ClientId);

      entity.HasMany(client => client.Accounts)
       .WithOne(cr => cr.Client)
       .HasForeignKey(cr => cr.ClientId)
       .OnDelete(DeleteBehavior.ClientSetNull);

      entity.HasMany(client => client.DebitCards)
        .WithOne(cr => cr.Client)
        .HasForeignKey(cr => cr.ClientId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      entity.HasMany(client => client.CreditCards)
        .WithOne(dr => dr.Client)
        .HasForeignKey(dr => dr.ClientId)
        .OnDelete(DeleteBehavior.ClientSetNull);

       entity.HasMany(client => client.Loans)
        .WithOne(dr => dr.Client)
        .HasForeignKey(dr => dr.ClientId)
        .OnDelete(DeleteBehavior.ClientSetNull);

      entity.HasMany(client => client.Products)
        .WithOne(dr => dr.Client)
        .HasForeignKey(dr => dr.ClientId)
        .OnDelete(DeleteBehavior.ClientSetNull);
    }
  }
}
