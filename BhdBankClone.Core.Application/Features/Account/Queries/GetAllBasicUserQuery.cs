using BhdBankClone.Core.Application.DTOs.AccountQueries;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Account.Queries
{
  public class GetAllBasicUserQuery: IRequest<Response<List<BasicUserDTO>>>
  {
  }

  internal class GetAllBasicUserQueryHandler : IRequestHandler<GetAllBasicUserQuery, Response<List<BasicUserDTO>>>
  {
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;

    public GetAllBasicUserQueryHandler(IBasicUserExtraAccountService basicUserExtraAccountService)
    {
      _basicUserExtraAccountService = basicUserExtraAccountService;
    }

    public async Task<Response<List<BasicUserDTO>>> Handle(GetAllBasicUserQuery request, CancellationToken cancellationToken)
    {
      var basicUsers = await _basicUserExtraAccountService.GetAllBasicUserAsync();
      
      if (basicUsers == null) return new Response<List<BasicUserDTO>>() { Succeeded = true, Message = "No basic user found" };

      return new Response<List<BasicUserDTO>>() { Succeeded = true,Data = basicUsers };
    }
  }
}
