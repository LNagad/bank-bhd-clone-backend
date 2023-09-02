namespace BhdBankClone.Core.Application.DTOs.Accounts
{
  public class ResetPasswordRequest
  {
    public string Token { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
