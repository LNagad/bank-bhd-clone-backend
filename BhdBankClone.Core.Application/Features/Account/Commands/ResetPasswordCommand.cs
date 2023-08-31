using BhdBankClone.Core.Application.DTOs.Account;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.Account.Commands
{
  public class ResetPasswordCommand : IRequest<Response<ResetPasswordResponse>>
  {
    public required ResetPasswordRequest ResetPasswordRequest;
  }


  public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response<ResetPasswordResponse>>
  {
    private readonly IAccountService _accountService;
    private readonly IValidator<ResetPasswordCommand> _validator;

    public ResetPasswordCommandHandler(IAccountService accountService, IValidator<ResetPasswordCommand> validator)
    {
      _accountService = accountService;
      _validator = validator;
    }

    public async Task<Response<ResetPasswordResponse>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      var response = await _accountService.ResetPasswordAsync(request.ResetPasswordRequest);

      if (response.HasError) throw new ApiException(response.Error!, (int)HttpStatusCode.BadRequest);

      return new Response<ResetPasswordResponse> { Succeeded = true, Data = response };
    }
  }
}
