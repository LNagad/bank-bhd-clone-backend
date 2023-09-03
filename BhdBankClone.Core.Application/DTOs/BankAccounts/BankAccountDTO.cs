

namespace BhdBankClone.Core.Application.DTOs.BankAccounts
{
  public class BankAccountDTO
  {
    public int Id { get; set; }
    public string? AccountNumber { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    public int? AccountTypeId { get; set; }

    public int? ClientId { get; set; }

    public int? ProductId { get; set; }

    public int? DebitCardId { get; set; }

    public decimal? CurrentBalance { get; set; }
  }
}
