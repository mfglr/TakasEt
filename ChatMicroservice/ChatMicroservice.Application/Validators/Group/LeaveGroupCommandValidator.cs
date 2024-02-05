using ChatMicroservice.Application.Dtos;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
	public class LeaveGroupCommandValidator : AbstractValidator<LeaveGroupDto>
	{
		public LeaveGroupCommandValidator()
		{
			RuleFor(x => x.UserId).NotNull().WithMessage("error");
			RuleFor(x => x.GroupId).NotNull().WithMessage("error");
		}
	}
}
