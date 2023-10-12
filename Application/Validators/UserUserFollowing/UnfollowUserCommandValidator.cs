using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class UnfollowUserCommandValidator : AbstractValidator<UnfollowUser>
    {
        public UnfollowUserCommandValidator()
        {
            RuleFor(x => x.FollowedId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
