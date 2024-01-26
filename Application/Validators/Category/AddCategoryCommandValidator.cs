using FluentValidation;
using Models.Dtos;

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
