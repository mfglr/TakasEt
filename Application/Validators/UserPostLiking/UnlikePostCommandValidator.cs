using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class UnlikePostCommandValidator : AbstractValidator<DislikePostDto>
    {
        public UnlikePostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
