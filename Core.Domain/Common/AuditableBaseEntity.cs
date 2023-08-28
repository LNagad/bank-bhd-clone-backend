namespace BhdBankClone.Core.Domain.Common
{
  public class AuditableBaseEntity
  {
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
  }
}
