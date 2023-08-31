namespace BhdBankClone.Core.Application.DTOs.AccountQueries
{
  public class BasicUserDTO
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    public int? ClientId { get; set; }
  }
}
