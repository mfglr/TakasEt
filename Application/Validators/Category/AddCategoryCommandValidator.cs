using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryRequestDto>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Hata");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Hata");
        }
    }
}
