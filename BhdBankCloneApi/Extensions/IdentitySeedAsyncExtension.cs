using BhdBankClone.Infrastructure.Identity.Entities;
using BhdBankClone.Infrastructure.Identity.Seeds;
using Microsoft.AspNetCore.Identity;

namespace BhdBankCloneApi.Extensions
{
  public static class IdentitySeedAsyncExtension
  {
    public static async Task AddIdentitySeed(this IServiceProvider serviceProvider)
    {
      using (var scope = serviceProvider.CreateScope())
      {
        var services = scope.ServiceProvider;

        try
        {
          var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
          var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

          await DefaultRoles.SeedAsync(userManager, roleManager);
          await DefaultBasicUser.SeedAsync(userManager, roleManager);
          await DefaultModeratorUser.SeedAsync(userManager, roleManager);
          await DefaultAdminUser.SeedAsync(userManager, roleManager);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

    }
  }
}
