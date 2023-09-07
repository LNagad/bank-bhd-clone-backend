using AutoMapper;
using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.CreditCards;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.ProductTypes;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Features.BankAccounts.Commands;
using BhdBankClone.Core.Application.Features.BankAccountTypes.Command;
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
        .ForMember(dest => dest.SourceTransaction, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationTransactions, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<LoanDTO, Loan>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.SourceTransaction, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationTransactions, opt => opt.Ignore())
      .ReverseMap();
      #endregion

      #region DebitCards
      CreateMap<CreateDebitCardCommand, DebitCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<DebitCardDTO, DebitCard>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.Account, opt => opt.Ignore())
        .ForMember(dest => dest.Product, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
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
        .ForMember(dest => dest.Products, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<BankAccountDTO, Account>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.AccountType, opt => opt.Ignore())
        .ForMember(dest => dest.DebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.Products, opt => opt.Ignore())
        .ForMember(dest => dest.Transactions, opt => opt.Ignore())
        .ReverseMap();
      #endregion

      #region BankAccountTypes
      CreateMap<CreateBankAccountTypeCommand, AccountType>()
        .ForMember(dest => dest.Accounts, opt => opt.Ignore())
      .ReverseMap();

      CreateMap<BankAccountTypeDTO, AccountType>()
        .ForMember(dest => dest.Accounts, opt => opt.Ignore())
        .ReverseMap();
      #endregion
      
      #region Transactions
      CreateMap<CreateTransactionCommand, BankTransaction>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationAccount, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationLoan, opt => opt.Ignore())
        .ForMember(dest => dest.SourceAccount, opt => opt.Ignore())
        .ForMember(dest => dest.SourceCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.SourceDebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
      .ReverseMap()
        .ForMember(dest => dest.SourceAccountId, opt => opt.MapFrom(src => src.SourceAccountId == 0 ? (int?)null : src.SourceAccountId))
        .ForMember(dest => dest.SourceCreditCardId, opt => opt.MapFrom(src => src.SourceCreditCardId == 0 ? (int?)null : src.SourceCreditCardId))
        .ForMember(dest => dest.DestinationCreditCardId, opt => opt.MapFrom(src => src.DestinationCreditCardId == 0 ? (int?)null : src.DestinationCreditCardId))
        .ForMember(dest => dest.DestinationAccountId, opt => opt.MapFrom(src => src.DestinationAccountId == 0 ? (int?)null : src.DestinationAccountId))
        .ForMember(dest => dest.DestinationLoanId, opt => opt.MapFrom(src => src.DestinationLoanId == 0 ? (int?)null : src.DestinationLoanId));

      CreateMap<TransactionDTO, BankTransaction>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationAccount, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationLoan, opt => opt.Ignore())
        .ForMember(dest => dest.SourceAccount, opt => opt.Ignore())
        .ForMember(dest => dest.SourceCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.SourceDebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
      .ReverseMap();
      #endregion

      #region FavoriteTransaction
      CreateMap<CreateFavoriteTransactionCommand, FavoriteTransaction>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationAccount, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationLoan, opt => opt.Ignore())
        .ForMember(dest => dest.SourceAccount, opt => opt.Ignore())
        .ForMember(dest => dest.SourceCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.SourceDebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
      .ReverseMap()
        .ForMember(dest => dest.SourceAccountId, opt => opt.MapFrom(src => src.SourceAccountId == 0 ? (int?)null : src.SourceAccountId))
        .ForMember(dest => dest.SourceCreditCardId, opt => opt.MapFrom(src => src.SourceCreditCardId == 0 ? (int?)null : src.SourceCreditCardId))
        .ForMember(dest => dest.DestinationCreditCardId, opt => opt.MapFrom(src => src.DestinationCreditCardId == 0 ? (int?)null : src.DestinationCreditCardId))
        .ForMember(dest => dest.DestinationAccountId, opt => opt.MapFrom(src => src.DestinationAccountId == 0 ? (int?)null : src.DestinationAccountId))
        .ForMember(dest => dest.DestinationLoanId, opt => opt.MapFrom(src => src.DestinationLoanId == 0 ? (int?)null : src.DestinationLoanId));

      CreateMap<FavoriteTransactionDTO, FavoriteTransaction>()
        .ForMember(dest => dest.Client, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationAccount, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.DestinationLoan, opt => opt.Ignore())
        .ForMember(dest => dest.SourceAccount, opt => opt.Ignore())
        .ForMember(dest => dest.SourceCreditCard, opt => opt.Ignore())
        .ForMember(dest => dest.SourceDebitCard, opt => opt.Ignore())
        .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
      .ReverseMap();
      #endregion
    }
  }
}
