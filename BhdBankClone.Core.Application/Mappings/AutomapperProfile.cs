using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.Features.Clients.Commands;
using BhdBankClone.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
  }
}
