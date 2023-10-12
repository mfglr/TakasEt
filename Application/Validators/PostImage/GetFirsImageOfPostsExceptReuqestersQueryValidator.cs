using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetFirsImageOfPostsExceptReuqestersQueryValidator : AbstractValidator<GetFirstImagesOfPostsExceptRequesters>
	{
        public GetFirsImageOfPostsExceptReuqestersQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
