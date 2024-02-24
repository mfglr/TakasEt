using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    public class LoginByRefreshTokenCommandValidator : AbstractValidator<LoginByRefreshTokenDto>
    {
        public LoginByRefreshTokenCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("User id is required!");
            RuleFor(x => x.Token).NotEmpty().NotNull().WithMessage("Token id is required!");
        }
    }
}
