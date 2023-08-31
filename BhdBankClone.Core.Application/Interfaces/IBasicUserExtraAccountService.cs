using BhdBankClone.Core.Application.DTOs.AccountQueries;

namespace BhdBankClone.Core.Application.Interfaces
{
  public interface IBasicUserExtraAccountService
  {
    Task<List<BasicUserDTO>?> GetAllBasicUserAsync();
    Task<bool> UserExist(string Id);
  }
}