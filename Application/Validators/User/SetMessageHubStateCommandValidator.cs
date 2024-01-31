using Models.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
	public class SetMessageHubStateCommandValidator : AbstractValidator<SetMessageHubStateDto>
	{
		public SetMessageHubStateCommandValidator(IRepository<User> _users)
		{
			RuleFor(x => x.UserId).NotNull().WithMessage("error");
			RuleFor(x => x.ConnectionId).NotNull().WithMessage("error");

			RuleFor(x => x.UserId)
				.MustAsync(
					async (userId, cancellationToken) =>
					{
						return await _users.DbSet.AnyAsync(x => x.Id == userId, cancellationToken);
					}
				)
				.WithMessage("error");
		}

	}
}
