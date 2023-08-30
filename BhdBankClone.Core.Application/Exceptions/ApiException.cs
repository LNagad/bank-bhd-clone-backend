using System.Globalization;

namespace BhdBankClone.Core.Application.Exceptions
{
  public class ApiException : Exception
  {
    public int StatusCode { get; set; }

    public ApiException() { }

    public ApiException(string message, int statusCode) : base(message)
    {
      StatusCode = statusCode;
    }

    // This constructor is recommended to implement in order fullfill all they possible scenarios
    //params object[] args // This is a parameter array, it means that you can pass as many arguments as you want
    public ApiException(string message, params object[] args)
      : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
  }
}
