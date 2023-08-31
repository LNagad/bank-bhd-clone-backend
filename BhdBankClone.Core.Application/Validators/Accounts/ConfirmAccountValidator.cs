using BhdBankClone.Core.Application.Features.Account.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Accounts
{
  public class ConfirmAccountValidator : AbstractValidator<ConfirmAccountCommand>
  {
    public ConfirmAccountValidator()
    {
      RuleFor(x => x.ConfirmAccountRequest.UserId).NotEmpty().WithMessage("UserId is required");
      RuleFor(x => x.ConfirmAccountRequest.Token).NotEmpty().WithMessage("Token is required");
    }
  }
}
