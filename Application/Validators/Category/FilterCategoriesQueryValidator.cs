using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class FilterCategoriesQueryValidator : AbstractValidator<FilterCategories>
    {
        public FilterCategoriesQueryValidator()
        {
            RuleFor(x => x.Key).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
