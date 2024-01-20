using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class FilterCategoriesQueryValidator : AbstractValidator<FilterCategoriesDto>
    {
        public FilterCategoriesQueryValidator()
        {
            RuleFor(x => x.Key).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
