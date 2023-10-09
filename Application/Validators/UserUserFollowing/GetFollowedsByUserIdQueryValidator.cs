using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetFollowedsByUserIdQueryValidator : AbstractValidator<GetFollowedsByUserIdRequestDto>
    {
        public GetFollowedsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
