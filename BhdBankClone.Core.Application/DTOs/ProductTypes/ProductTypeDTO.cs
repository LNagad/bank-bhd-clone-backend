namespace BhdBankClone.Core.Application.DTOs.ProductTypes
{
  public class ProductTypeDTO
  {
    public int Id { get; set; }
    public required string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
  }
}
