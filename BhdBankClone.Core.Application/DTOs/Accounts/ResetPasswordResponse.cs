namespace BhdBankClone.Core.Application.DTOs.Accounts
{
  public class ResetPasswordResponse
  {
    public bool HasError { get; set; }
    public string Error { get; set; }
    public string OkResult { get; set; }
  }
}
