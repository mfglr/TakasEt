using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators.Message
{
    public class LikeGroupMessageCommandValidator : AbstractValidator<LikeGroupMessageDto>
    {
        public LikeGroupMessageCommandValidator()
        {
            RuleFor(x => x.GroupId).NotNull().WithMessage("Group id is required");
            RuleFor(x => x.LikerId).NotNull().WithMessage("User id is required!");
            RuleFor(x => x.MessageId).NotNull().WithMessage("Message id is required!");
        }
    }
}
