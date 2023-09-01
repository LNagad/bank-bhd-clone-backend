using BhdBankClone.Core.Application.DTOs.AccountQueries;
using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Domain.settings;
using BhdBankClone.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BhdBankClone.Infrastructure.Identity.Services
{
  public class BasicUserExtraAccountService : IBasicUserExtraAccountService
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly JWTSettings _jwtSettings;

    public BasicUserExtraAccountService(
     UserManager<ApplicationUser> userManager,
     RoleManager<IdentityRole> roleManager
      )
    {
      _userManager = userManager;
      _roleManager = roleManager;
    }

    public async Task<bool> UserExist(string Id)
    {
      return await _userManager.FindByIdAsync(Id) != null ? true : false;
    }

    public async Task<BasicUserDTO> GetBasicUserByIdAsync(string Id)
    {
      var user = await _userManager.FindByIdAsync(Id);
      return new BasicUserDTO
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        PhoneNumber = user.PhoneNumber,
        UserName = user.UserName,
        Id = user.Id,
        IsActive = user.IsActive,
        ClientId = user.ClientId
      };
    }

    public async Task<List<BasicUserDTO>?> GetAllBasicUserAsync()
    {

      var basicRole = await _roleManager.FindByNameAsync(Roles.Basic.ToString());

      if (basicRole == null) return null;

      // usersInAdminRole contiene la lista de usuarios que pertenecen al rol "admin"
      var allUsersInBasicRole = await _userManager.GetUsersInRoleAsync(basicRole.Name);

      string adminEmail = "adminuser@email.com";

      allUsersInBasicRole = allUsersInBasicRole.Where(user => user.Email != adminEmail).ToList();
      
      var list = new List<BasicUserDTO>();

      foreach( var user in allUsersInBasicRole)
      {
        list.Add(new BasicUserDTO
        {
          FirstName = user.FirstName,
          LastName = user.LastName,
          Email = user.Email,
          PhoneNumber = user.PhoneNumber,
          UserName = user.UserName,
          Id = user.Id,
          IsActive = user.IsActive,
          ClientId = user.ClientId
        });
      }

      return list;
    }
  }
}
