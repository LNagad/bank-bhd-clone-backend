using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ClientStatusConfig : IEntityTypeConfiguration<ClientStatus>
  {
    
    public void Configure(EntityTypeBuilder<ClientStatus> entity)
    {

      entity.ToTable("client_statuses");
      
      entity.HasKey(e => e.Id);

      entity.HasIndex(e => e.Description)
            .HasName("client_statuses_index_11")
            .IsUnique();

      entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

      entity.HasMany<Client>()
        .WithOne(client => client.ClientStatus)
        .HasForeignKey(client => client.StatusId);
    }
  }
}
