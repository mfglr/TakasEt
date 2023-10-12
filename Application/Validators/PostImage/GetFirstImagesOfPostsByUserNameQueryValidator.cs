using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetFirstImagesOfPostsByUserNameQueryValidator : AbstractValidator<GetFirstImagesOfPostsByUserName>
	{
        public GetFirstImagesOfPostsByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
