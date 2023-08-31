using BhdBankClone.Core.Application.Features.Account.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Accounts
{
  public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
  {

    public AuthenticateValidator()
    {
      RuleFor(x => x.AuthenticationRequest.Email)
        .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email is not valid");

      RuleFor(x => x.AuthenticationRequest.Password)
        .NotEmpty().WithMessage("Password is required")
        .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
  }
}
