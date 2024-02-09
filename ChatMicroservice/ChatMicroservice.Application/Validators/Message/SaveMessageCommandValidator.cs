using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
    public class SaveMessageCommandValidator : AbstractValidator<SaveMessageDto>
    {
        public SaveMessageCommandValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required!");
            RuleFor(x => x.SenderId).NotNull().WithMessage("SenderId is required!");
            RuleFor(x => x)
                .Must(x => x.ReceiverId != null || x.GroupId != null)
                .WithMessage("Either ReciverId or GroupId is required!");
        }
    }
}
