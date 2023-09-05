using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BhdBankClone.Infrastructure.Persistence
{
  public static class ServiceRegistration
  {
    public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config)
    {
      AddRepositories(services);

      services.AddDbContext<ApplicationContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
        m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
      });

      return services;
    }

    #region Private Methods
    private static void AddRepositories(this IServiceCollection services)
    {
      //services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddTransient<IClientRepository, ClientRepository>();
      services.AddTransient<IClientStatusRepository, ClientstatusRepository>();
      services.AddTransient<IProductRepository, ProductRepository>();
    }
    #endregion
  }
}
