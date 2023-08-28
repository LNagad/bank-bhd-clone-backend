using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BhdBankClone.Infrastructure.Identity.Seeds
{
  public static class DefaultBasicUser
  {
    public static async Task SeedAsync
    (UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      ApplicationUser defaultUser = new()
      {
        UserName = "basicUser",
        Email = "basicuser@email.com",
        FirstName = "John",
        LastName = "Doe",
        EmailConfirmed = true,
        PhoneNumberConfirmed = true,
        IsActive = true,
      };

      if( userManager.Users.All( user => user.Id != defaultUser.Id ) )
      {
        var userExist = await userManager.FindByEmailAsync(defaultUser.Email);
        if(userExist == null )
        {
          await userManager.CreateAsync(defaultUser, "Pa$$w0rd1234");
          await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
        }
      
      }

    }
  }
}
