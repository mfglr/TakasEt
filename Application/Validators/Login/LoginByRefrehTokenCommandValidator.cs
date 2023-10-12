using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class LoginByRefrehTokenCommandValidator : AbstractValidator<LoginByRefreshToken>
	{
        public LoginByRefrehTokenCommandValidator()
        {
            RuleFor(x => x.RefreshToken).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
