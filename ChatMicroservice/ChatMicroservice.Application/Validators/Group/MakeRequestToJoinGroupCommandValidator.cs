using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
	public class MakeRequestToJoinGroupCommandValidator : AbstractValidator<MakeRequestToJoinGroupDto>
	{
        public MakeRequestToJoinGroupCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty().NotNull().WithMessage("error");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("error");
        }

    }
}
