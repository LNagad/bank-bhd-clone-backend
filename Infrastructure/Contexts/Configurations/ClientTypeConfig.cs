using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BhdBankClone.Infrastructure.Persistence.Contexts.Configurations
{
  public class ClientTypeConfig : IEntityTypeConfiguration<ClientType>
  {
    public void Configure(EntityTypeBuilder<ClientType> entity)
    {

      entity.ToTable("clients_types");

      entity.HasKey(e => e.Id);

      entity.Property(e => e.Description)
              .HasMaxLength(100)
              .IsUnicode(false)
              .IsRequired();

      entity.HasIndex(e => e.Description, "UQ__clients___489B0D974E8DBA8C").IsUnique();

      entity.HasIndex(e => e.Description, "clients_types_index_13");

      // Disabling auto include of related entities

      entity.Navigation(clientType => clientType.Clients)
        .AutoInclude(false);

      // Adding data to the table
      entity.HasData(
        new ClientType() 
        { 
          Id = (int)Clients.CLIENTE_TIPO_PERSONAL, 
          Description = Clients.CLIENTE_TIPO_PERSONAL.ToString()
        },
        new ClientType() { 
          Id = (int)Clients.CLIENTE_TIPO_EMPRESARIAL,
          Description = Clients.CLIENTE_TIPO_EMPRESARIAL.ToString()
        }
      );
    }
  }
}
