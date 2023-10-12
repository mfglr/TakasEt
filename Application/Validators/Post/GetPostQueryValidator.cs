using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetPostQueryValidator : AbstractValidator<GetPost>
    {
        public GetPostQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
