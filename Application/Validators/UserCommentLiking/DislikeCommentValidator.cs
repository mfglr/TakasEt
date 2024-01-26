using FluentValidation;
using Models.Dtos;

namespace Application.Validators.UserCommentLiking
{
	public class DislikeCommentValidator : AbstractValidator<DislikeCommentDto>
	{
        public DislikeCommentValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("hata");
        }
    }
}
