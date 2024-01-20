using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class RemoveCommentValidator : AbstractValidator<RemoveCommentDto>
    {
        public RemoveCommentValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
