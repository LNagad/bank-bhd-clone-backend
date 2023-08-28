namespace BhdBankClone.Core.Domain.settings
{
  public class JWTSettings
  {
    public required string SecretKey { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int DurationInMinutes { get; set; }
  }
}
