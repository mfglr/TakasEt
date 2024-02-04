using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
	public class CreateGroupCommandValidator : AbstractValidator<CreateGroupDto>
	{
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("error");
            RuleFor(x => x.Description).NotEmpty().WithMessage("error");
            RuleFor(x => x.Users.Count).GreaterThan(0).WithMessage("error");
        }
    }
}
