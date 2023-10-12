using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetFollowersQueryValidator : AbstractValidator<GetFollowers>
    {
        public GetFollowersQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
