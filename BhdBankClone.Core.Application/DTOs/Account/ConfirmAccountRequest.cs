﻿namespace BhdBankClone.Core.Application.DTOs.Account
{
  public class ConfirmAccountRequest
  {
    public string UserId { get; set; }
    public string Token { get; set; }
  }
}