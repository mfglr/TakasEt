using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class UnlikePostCommandValidator : AbstractValidator<UnLikePost>
    {
        public UnlikePostCommandValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
