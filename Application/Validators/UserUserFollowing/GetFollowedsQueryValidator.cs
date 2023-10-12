using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetFollowedsQueryValidator : AbstractValidator<GetFolloweds>
    {
        public GetFollowedsQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
