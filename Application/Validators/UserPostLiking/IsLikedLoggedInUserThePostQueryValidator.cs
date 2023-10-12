using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserPostLike
{
	public class IsLikedLoggedInUserThePostQueryValidator : AbstractValidator<IsLikedLoggedInUserThePost>
	{
        public IsLikedLoggedInUserThePostQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
