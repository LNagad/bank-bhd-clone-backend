using BhdBankClone.Core.Application.DTOs.Accounts;
using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.IdentityAccount.Commands
{
  public class RegisterCommand : IRequest<Response<RegisterResponse>>
  {
    public required RegisterRequest RegisterRequest { get; set; }
    public required string Origin { get; set; }
    public Roles? Role { get; set; }
  }

  public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<RegisterResponse>>
  {

    private readonly IAccountService _accountService;
    private readonly IValidator<RegisterCommand> _validator;

    public RegisterCommandHandler(IAccountService accountService, IValidator<RegisterCommand> validator)
    {
      _accountService = accountService;
      _validator = validator;
    }

    public async Task<Response<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      var resp = await _accountService.RegisterBasicUserAsync(request.RegisterRequest, request.Origin);

      if (resp.HasError) throw new ApiException(resp.Error, (int)HttpStatusCode.BadRequest);

      return new Response<RegisterResponse>() { Data = resp, Succeeded = true, Errors = null };
    }
  }
}
