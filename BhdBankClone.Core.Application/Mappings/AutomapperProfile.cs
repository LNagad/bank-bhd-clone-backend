using AutoMapper;
using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.CreditCards;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.ProductTypes;
using BhdBankClone.Core.Application.Features.BankAccounts.Commands;
using BhdBankClone.Core.Application.Features.Clients.Commands;
using BhdBankClone.Core.Application.Features.CreditCards.Commands;
using BhdBankClone.Core.Application.Features.DebitCards.Commands;
using BhdBankClone.Core.Application.Features.Loans.Commands;
using BhdBankClone.Core.Application.Features.Products.Commands;
using BhdBankClone.Core.Application.Features.ProductTypes.Commands;
using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Mappings
{
  public class AutomapperProfile : Profile
  {
    public AutomapperProfile()
    {

      #region Client
      CreateMap<CreateClientCommand, Client>()
        .ForMember(dest => dest.Products, opt => opt.Ignore())
        .ForMember(dest => dest.Accounts, opt => opt.Ignore())
        .ForMember(dest => dest.ClientStatus, opt => opt.Ignore())
        .ForMember(dest => dest.CreditCards, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCards, opt => opt.Ignore())
        .ForMember(dest => dest.ClientType, opt => opt.Ignore())
        .ForMember(dest => dest.Loans, opt => opt.Ignore())
        .ReverseMap();

      CreateMap<ClientDTO, Client>()
       .ForMember(dest => dest.Products, opt => opt.Ignore())
       .ForMember(dest => dest.Accounts, opt => opt.Ignore())
       .ForMember(dest => dest.ClientStatus, opt => opt.Ignore())
       .ForMember(dest => dest.CreditCards, opt => opt.Ignore())
       .ForMember(dest => dest.DebitCards, opt => opt.Ignore())
       .ForMember(dest => dest.ClientType, opt => opt.Ignore())
       .ForMember(dest => dest.Loans, opt => opt.Ignore())
       .ReverseMap();
      #endregion

      #region ProductTypes
      CreateMap<ProductTypeDTO, ProductType>()
        .ReverseMap();
      
      CreateMap<CreateProductTypeCommand, ProductType>()
        .ReverseMap();
      #endregion

      #region Products
      CreateMap<CreateProductCommand, Product>()
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Loan, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.CreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.ProductType, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<ProductDTO, Product>()
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Loan, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.CreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.ProductType, opt => opt.Ignore())
      .ReverseMap();
      #endregion

      #region Loans
      CreateMap<CreateLoanCommand, Loan>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionSourceDebitCard, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<LoanDTO, Loan>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionSourceDebitCard, opt => opt.Ignore())
      .ReverseMap();
      #endregion

      #region DebitCards
      CreateMap<CreateDebitCardCommand, DebitCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionSourceDebitCard, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<DebitCardDTO, DebitCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionSourceDebitCard, opt => opt.Ignore())
      .ReverseMap();
      #endregion

      #region CreditCards
      CreateMap<CreateCreditCardCommand, CreditCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<CreditCardDTO, CreditCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
        .ReverseMap();
      #endregion

      #region BankAccounts
      CreateMap<CreateBankAccountCommand, Account>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.AccountType, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<BankAccountDTO, Account>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.AccountType, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
        .ReverseMap();
      #endregion
    }
  }
}
