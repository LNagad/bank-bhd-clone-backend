using BhdBankClone.Core.Application.Features.IdentityAccount.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace BhdBankClone.Core.Application.Validators.Accounts
{
  public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordCommand>
  {
    public ForgotPasswordValidator()
    {
      RuleFor(x => x.ForgotPasswordRequest.Email).Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email is not valid");
      RuleFor(x => x.Origin).Custom((origin, context) =>
      {
        Uri uriResult;
        bool isValidUri = Uri.TryCreate(origin, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (!isValidUri)
        {
          context.AddFailure(new ValidationFailure("Origin", "Origin is required"));
        }
      });
    }
  }
}
