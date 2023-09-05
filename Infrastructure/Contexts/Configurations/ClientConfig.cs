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

      entity.HasOne(client => client.ClientType)
        .WithMany(clientType => clientType.Clients)
        .HasForeignKey(client => client.ClientTypeId)
        .OnDelete(DeleteBehavior.ClientSetNull);

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

      // Disabling auto include for navigation properties
      entity.Navigation(client => client.ClientType).AutoInclude(false);
      entity.Navigation(client => client.ClientStatus).AutoInclude(false);
      entity.Navigation(client => client.Accounts).AutoInclude(false);
      entity.Navigation(client => client.CreditCards).AutoInclude(false);
      entity.Navigation(client => client.DebitCards).AutoInclude(false);
      entity.Navigation(client => client.Loans).AutoInclude(false);
      entity.Navigation(client => client.Products).AutoInclude(false);

      //entity.Ignore(client => client.ClientType);
      //entity.Ignore(client => client.ClientStatus);
      //entity.Ignore(client => client.Accounts);
      //entity.Ignore(client => client.CreditCards);
      //entity.Ignore(client => client.DebitCards);
      //entity.Ignore(client => client.Loans);
      //entity.Ignore(client => client.EProducts);
    }
  }
}
