

namespace BhdBankClone.Core.Application.DTOs.Clients
{
  public class ClientDTO
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? ClientsTypeId { get; set; }
    public required string IdentityCard { get; set; }
    public bool IsActive { get; set; }
    public int? StatusId { get; set; }
  }
}
