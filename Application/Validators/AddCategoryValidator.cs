using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddCategoryValidator : AbstractValidator<AddCategoryRequestDto>
	{
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Hata");
			RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Hata");
		}
	}
}
