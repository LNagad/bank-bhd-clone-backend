using BhdBankClone.Core.Application.DTOs.Accounts;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.IdentityAccount.Commands
{
  public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
  {
    public required AuthenticationRequest AuthenticationRequest { get; set; }
  }

  public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
  {
    private readonly IAccountService _accountService;
    private readonly IValidator<AuthenticateCommand> _authenticateValidator;

    public AuthenticateCommandHandler(IAccountService accountService, IValidator<AuthenticateCommand> authenticateValidator)
    {
      _accountService = accountService;
      _authenticateValidator = authenticateValidator;
    }

    public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _authenticateValidator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      var resp = await _accountService.SignInWithEmailAndPasswordAsync(request.AuthenticationRequest);

      if (resp.HasError) throw new ApiException(resp.Error, (int)HttpStatusCode.BadRequest);

      return new Response<AuthenticationResponse>() { Data = resp, Succeeded = true, Errors = null };
    }
  }
}
