using FluentValidation;
using Models.Dtos;

namespace Application.Validators
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentDto>
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
