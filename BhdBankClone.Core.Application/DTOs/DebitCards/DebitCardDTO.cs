

namespace BhdBankClone.Core.Application.DTOs.DebitCards
{
  public class DebitCardDTO
  {
    public int Id { get; set; }
    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

  }
}
