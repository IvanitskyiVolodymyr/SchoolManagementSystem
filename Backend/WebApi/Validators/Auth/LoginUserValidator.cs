using Common.Dtos.Auth;
using FluentValidation;

namespace WebApi.Validators.Auth
{
    public class LoginUserValidator : AbstractValidator<LoginDto>
    {
        public LoginUserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(u => u.Password).NotEmpty().NotNull();
        }
    }
}
