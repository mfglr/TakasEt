using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserPostLike
{
	public class IsLikedLoggedInUserPostQueryValidator : AbstractValidator<IsLikedLoggedInUserPostRequestDto>
	{
        public IsLikedLoggedInUserPostQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
