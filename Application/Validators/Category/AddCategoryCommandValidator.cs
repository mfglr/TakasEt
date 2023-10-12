using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategory>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Hata");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Hata");
        }
    }
}
