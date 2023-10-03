using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddProfileImageCommandValidator : AbstractValidator<AddProfileImageRequestDto>
	{
        public AddProfileImageCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Stream).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Extention).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
