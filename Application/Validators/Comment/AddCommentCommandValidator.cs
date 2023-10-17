using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddCommentCommandValidator : AbstractValidator<AddComment>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("hata");
            RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("hata");
            RuleFor(x => x).Must(
                x =>
                    x.ParentId == null && x.PostId != null ||
                    x.ParentId != null && x.PostId == null
            );

        }
    }
}
