﻿namespace BhdBankClone.Core.Application.DTOs.Accounts
{
  public class RegisterResponse
  {
    public bool HasError { get; set; }
    public string Error { get; set; }
    public string OkResult { get; set; }
  }
}
