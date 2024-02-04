using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators.Connection
{
	public class DisconnectCommandValidator : AbstractValidator<DisconnectDto>
	{
        public DisconnectCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("error");
        }
    }
}
