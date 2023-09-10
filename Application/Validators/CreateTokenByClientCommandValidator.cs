using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class CreateTokenByClientCommandValidator : AbstractValidator<ClientLoginDto>
	{
        public CreateTokenByClientCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Secret).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
