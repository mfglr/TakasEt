using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class LoginByRefrehTokenCommandValidator : AbstractValidator<LoginByRefreshTokenDto>
	{
        public LoginByRefrehTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
