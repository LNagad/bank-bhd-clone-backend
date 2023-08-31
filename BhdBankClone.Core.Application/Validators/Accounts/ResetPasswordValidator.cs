using BhdBankClone.Core.Application.Features.Account.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Accounts
{
  public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
  {

    public ResetPasswordValidator()
    {
      RuleFor(x => x.ResetPasswordRequest.Email)
        .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email is not valid");

      RuleFor(x => x.ResetPasswordRequest.Token)
        .NotEmpty().WithMessage("Token");

      RuleFor(x => x.ResetPasswordRequest.Password)
        .NotEmpty().WithMessage("Password is required")
        .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
  }
}
