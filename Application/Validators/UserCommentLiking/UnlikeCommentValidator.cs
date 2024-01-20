using Application.Dtos;
using FluentValidation;

namespace Application.Validators.UserCommentLiking
{
	public class UnlikeCommentValidator : AbstractValidator<DislikeCommentDto>
	{
        public UnlikeCommentValidator()
        {
            RuleFor(x => x.CommentId).NotNull().WithMessage("hata");
        }
    }
}
