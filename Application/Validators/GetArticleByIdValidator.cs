using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetArticleByIdValidator : AbstractValidator<GetPostByIdRequestDto>
	{
        public GetArticleByIdValidator()
        {
			RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
