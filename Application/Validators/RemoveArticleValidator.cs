using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class RemoveArticleValidator : AbstractValidator<RemoveArticleRequestDto>
	{
        public RemoveArticleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
