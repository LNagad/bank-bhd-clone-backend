using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BhdBankClone.Core.Application
{
  public static class ServiceRegistration 
  {
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration config)
    {
   
      return services;
    }
  }
}
