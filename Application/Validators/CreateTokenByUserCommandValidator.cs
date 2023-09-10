using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class CreateTokenByUserCommandValidator : AbstractValidator<LoginDto>
	{
        public CreateTokenByUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
