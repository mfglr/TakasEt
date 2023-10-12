using Application.Dtos.Post;
using FluentValidation;

namespace Application.Validators
{
	public class GetPostsExceptRequestersQueryValidator : AbstractValidator<GetPostsExceptRequesters>
	{
        public GetPostsExceptRequestersQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
