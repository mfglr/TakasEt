using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Hata");
        }
    }
}
