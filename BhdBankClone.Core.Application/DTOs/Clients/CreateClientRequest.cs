
namespace BhdBankClone.Core.Application.DTOs.Client
{
  public class CreateClientRequest
  {
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? ClientsTypeId { get; set; }
    public string? IdentityCard { get; set; }
    public bool? IsActive { get; set; }
    public int? StatusId { get; set; }
  }
}
