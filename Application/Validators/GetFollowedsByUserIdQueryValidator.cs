using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetFollowedsByUserIdQueryValidator : AbstractValidator<GetFollowedsByUserIdRequestDto>
	{
        public GetFollowedsByUserIdQueryValidator()
        {
            RuleFor(x => x.FollowerId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
