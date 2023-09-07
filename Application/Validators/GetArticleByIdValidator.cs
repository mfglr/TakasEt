using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetArticleByIdValidator : AbstractValidator<GetArticleByIdRequestDto>
	{
        public GetArticleByIdValidator()
        {
			RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
