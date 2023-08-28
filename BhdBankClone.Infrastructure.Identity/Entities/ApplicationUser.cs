using BhdBankClone.Core.Domain;
using Microsoft.AspNetCore.Identity;

namespace BhdBankClone.Infrastructure.Identity.Entities
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }

    public int? ClientId { get; set; }
  }
}
