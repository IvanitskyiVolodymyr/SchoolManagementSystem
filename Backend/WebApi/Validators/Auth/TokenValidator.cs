using Common.Dtos.Auth;
using FluentValidation;

namespace WebApi.Validators.Auth
{
    public class TokenValidator : AbstractValidator<TokenModel>
    {
        public TokenValidator()
        {
            RuleFor(t => t.AccessToken).NotNull().NotEmpty();
            RuleFor(t => t.RefreshToken).NotNull().NotEmpty();
        }
    }
}
