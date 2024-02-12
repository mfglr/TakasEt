using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
    public class SaveGroupMessageCommandValidator : AbstractValidator<SaveGroupMessageDto>
    {
        public SaveGroupMessageCommandValidator()
        {
            RuleFor(x => x.Content).NotNull().WithMessage("Content is required!");
            RuleFor(x => x.SenderId).NotNull().WithMessage("SenderId is required!");
            RuleFor(x => x.GroupId).NotNull().WithMessage("GroupId is required!");
        }
    }
}
