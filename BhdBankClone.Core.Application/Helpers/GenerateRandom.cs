namespace BhdBankClone.Core.Application.Helpers
{
  public static class GenerateRandom
  {
    public static string GenerateRandomNumber(int length)
    {
      Random random = new();
      string r = "";
      for (int i = 0; i < length; i++)
      {
        r += random.Next(0, 9).ToString();
      }
      return r;
    }
  }
}
