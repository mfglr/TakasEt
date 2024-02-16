using FluentValidation;
using UserService.Application.Dtos;

namespace UserService.Application.Validators
{
    public class FollowCommandValidator : AbstractValidator<FollowDto>
    {
        public FollowCommandValidator()
        {
            RuleFor(x => x.FollowerId).NotNull().WithMessage("Follower id is required!");
            RuleFor(x => x.FollowingId).NotNull().WithMessage("Following id is required!");
        }

    }
}
