using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddArticleValidators : AbstractValidator<AddPostRequestDto>
	{
        public AddArticleValidators()
        {
			RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("hata");
		}
    }
}
