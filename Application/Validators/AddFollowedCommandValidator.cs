using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class AddFollowedCommandValidator : AbstractValidator<AddFollowedRequestDto>
	{
        public AddFollowedCommandValidator()
        {
            RuleFor(x => x.FollowedId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
