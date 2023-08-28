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

      //services.AddTransient<IUnitOfWork, UnitOfWork>();
      //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

      services.AddDbContext<BhdContext>(opt =>
      {
        opt.UseSqlServer(config.GetConnectionString("DefaultConnection"),
        m => m.MigrationsAssembly(typeof(BhdContext).Assembly.FullName));
      });

      return services;
    }
  }
}
