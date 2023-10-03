using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class RemoveFollowedQueryValidator : AbstractValidator<RemoveFollowedRequestDto>
	{
        public RemoveFollowedQueryValidator()
        {
            RuleFor(x => x.FollowedId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
