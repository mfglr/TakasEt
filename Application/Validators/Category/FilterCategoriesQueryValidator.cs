using FluentValidation;
using Models.Dtos;

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
