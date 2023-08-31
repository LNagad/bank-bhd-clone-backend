using BhdBankClone.Core.Application.DTOs.Account;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.Account.Commands
{
  public class ForgotPasswordCommand : IRequest<Response<ForgotPasswordResponese>>
  {
    public required ForgotPasswordRequest ForgotPasswordRequest { get; set; }
    public required string Origin { get; set; }
  }

  public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Response<ForgotPasswordResponese>>
  {
    private readonly IAccountService _accountService;
    private readonly IValidator<ForgotPasswordCommand> _validator;

    public ForgotPasswordCommandHandler(IAccountService accountService, IValidator<ForgotPasswordCommand> validator)
    {
      _accountService = accountService;
      _validator = validator;
    }

    public async Task<Response<ForgotPasswordResponese>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      var response = await _accountService.ForgotPasswordAsync(request.ForgotPasswordRequest, request.Origin);

      if (response.HasError) throw new ApiException(response.Error!, (int)HttpStatusCode.BadRequest);

      return new Response<ForgotPasswordResponese> { Succeeded = true, Data = response };
    }
  }
}
