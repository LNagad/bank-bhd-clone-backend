using BhdBankClone.Core.Application.Features.Account.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace BhdBankClone.Core.Application.Validators.Accounts
{
  public class RegisterRequestValidator : AbstractValidator<RegisterCommand>
  {
    public RegisterRequestValidator()
    {
      RuleFor(x => x.RegisterRequest.FirstName).NotEmpty().WithMessage("First name is required");
      RuleFor(x => x.RegisterRequest.LastName).NotEmpty().WithMessage("Last name is required");
      RuleFor(x => x.RegisterRequest.UserName).NotEmpty().WithMessage("Username is required");
      RuleFor(x => x.RegisterRequest.Email).Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Email is not valid");
      RuleFor(x => x.RegisterRequest.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be at least 8 characters");
      RuleFor(x => x.RegisterRequest.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

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
