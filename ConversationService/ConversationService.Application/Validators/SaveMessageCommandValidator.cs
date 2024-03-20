using ConversationService.SignalR.Dtos;
using FluentValidation;

namespace ConversationService.Application.Validators
{
    public class SaveMessageCommandValidator : AbstractValidator<CreateMessageDto>
    {
        public SaveMessageCommandValidator()
        {
            RuleFor(x => x.ReceiverId).NotNull().WithMessage("Receiver id is required");
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required");

        }
    }
}
