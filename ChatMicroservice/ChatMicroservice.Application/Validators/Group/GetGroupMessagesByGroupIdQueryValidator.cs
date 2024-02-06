using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroservice.Application.Validators.Group
{
	public class GetGroupMessagesByGroupIdQueryValidator : AbstractValidator<GetGroupMessagesByGroupIdDto>
	{
		public GetGroupMessagesByGroupIdQueryValidator(ChatDbContext context)
		{
			RuleFor(x => x.UserId).NotNull().WithMessage("user id is required");

			RuleFor(x => x)
				.MustAsync(
					async (request,cancellationToken) =>
					{
						return await context
							.Groups
							.AsNoTracking()
							.AnyAsync(
								x =>
									x.Id == request.GroupId &&
									x.Users.Any(x => x.UserId == request.UserId),
								cancellationToken
							);
					}
				)
				.WithMessage($"The user is not a member of the group");
		}
	}
}
