using BhdBankClone.Core.Application.DTOs.Accounts;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Wrappers;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.Account.Commands
{
  public class ConfirmAccountCommand : IRequest<Response<ConfirmAccountResponse>>
  {
    public required ConfirmAccountRequest ConfirmAccountRequest { get; set; }
  }

  public class ConfirmAccountCommandHandler : IRequestHandler<ConfirmAccountCommand, Response<ConfirmAccountResponse>>
  {
    private readonly IAccountService _accountService;
    private readonly IValidator<ConfirmAccountCommand> _validator;

    public ConfirmAccountCommandHandler(IAccountService accountService, IValidator<ConfirmAccountCommand> validator)
    {
      _accountService = accountService;
      _validator = validator;
    }

    public async Task<Response<ConfirmAccountResponse>> Handle(ConfirmAccountCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      var response = await _accountService.ConfirmAccountAsync(request.ConfirmAccountRequest);

      if (response.HasError) throw new ApiException(response.Error!, (int)HttpStatusCode.BadRequest);

      return new Response<ConfirmAccountResponse> { Succeeded = true, Data = response };
    }
  }
}
