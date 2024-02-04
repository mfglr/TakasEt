using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
	public class ConnectCommandValidator : AbstractValidator<ConnectDto>
	{
        public ConnectCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("error");
            RuleFor(x => x.ConnectionId).NotEmpty().WithMessage("error");
        }
    }
}
