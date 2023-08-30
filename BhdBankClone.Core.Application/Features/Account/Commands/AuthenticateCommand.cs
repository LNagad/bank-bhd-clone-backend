using BhdBankClone.Core.Application.DTOs.Account;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Account.Commands
{
  public class AuthenticateCommand : IRequest<AuthenticationResponse>
  {
    public AuthenticationRequest authenticationRequest { get; set; }

  }

  public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticationResponse>
  {
    private readonly IAccountService _accountService;

    public AuthenticateCommandHandler(IAccountService accountService)
    {
      _accountService = accountService;
    }

    public async Task<AuthenticationResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
      var resp = await _accountService.SignInWithEmailAndPasswordAsync(request.authenticationRequest);

      if (resp.HasError)
      {
        throw new ApiException(resp.Error);
      }

      return resp;
    }
  }
}
