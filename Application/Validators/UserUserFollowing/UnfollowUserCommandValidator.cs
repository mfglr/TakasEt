using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class UnfollowUserCommandValidator : AbstractValidator<UnfollowUserDto>
    {
        public UnfollowUserCommandValidator()
        {
            RuleFor(x => x.FollowingId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
