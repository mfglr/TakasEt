using FluentValidation;
using Models.Dtos;

namespace Application.Validators
{
    public class DislikePostCommandValidator : AbstractValidator<DislikePostDto>
    {
        public DislikePostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
