using Application.Dtos;
using Application.Dtos.Authentication;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTokenByUserCommandValidator : AbstractValidator<CreateTokenByUserRequestDto>
	{
        public CreateTokenByUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
