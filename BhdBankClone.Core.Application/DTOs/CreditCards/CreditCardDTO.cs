﻿
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.DTOs.CreditCards
{
  public class CreditCardDTO
  {
    public int Id { get; set; }
    public decimal? CreditLimit { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? CreditCardDebt { get; set; }

    public string? CardNumber { get; set; }

    public DateTime? CardExpiryDate { get; set; }

    public string? CardCvv { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPrimary { get; set; }

    //public string? CardHolderName { get; set; }

    public int? ProductId { get; set; }

    public int? ClientId { get; set; }

    public ClientDTO? Client { get; set; }
    public ProductDTO? Product { get; set; }

    public ICollection<TransactionDTO>? Transactions { get; set; }
  }
}
