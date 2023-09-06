
namespace BhdBankClone.Core.Application.DTOs.Loans
{
  public class LoanDTO
  {
    public int Id { get; set; }
    public double? LoanAmount { get; set; }

    public bool? IsActive { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public int? AccountId { get; set; }
  }
}
