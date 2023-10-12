using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserUserFollowing
{
	public class IsFollowedQueryValidator : AbstractValidator<IsFollowed>
	{
        public IsFollowedQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
