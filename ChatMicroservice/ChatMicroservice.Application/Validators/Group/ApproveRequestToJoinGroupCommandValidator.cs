using ChatMicroservice.Application.Dtos.Group;
using FluentValidation;

namespace ChatMicroservice.Application.Validators
{
	public class ApproveRequestToJoinGroupCommandValidator : AbstractValidator<ApproveRequestToJoinGroupDto>
	{
		public ApproveRequestToJoinGroupCommandValidator()
		{
			RuleFor(x => x.GroupId).NotNull().WithMessage("error");
			RuleFor(x => x.IdOfUserWhoWantsToJoin).NotNull().WithMessage("error");
			RuleFor(x => x.IdOfUserApprovingRequest).NotNull().WithMessage("error");
		}
	}
}
