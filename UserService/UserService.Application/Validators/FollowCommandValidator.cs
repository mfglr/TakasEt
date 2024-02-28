using FluentValidation;
using UserService.Application.Dtos;

namespace UserService.Application.Validators
{
    public class FollowCommandValidator : AbstractValidator<FollowDto>
    {
        public FollowCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("User id is required!");
        }

    }
}
