using Application.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;
using System.Threading.Tasks.Dataflow;

namespace Application.Validators
{
    public class FollowUserCommandValidator : AbstractValidator<FollowUserDto>
    {
		private static string[] messages =
		{
			"Validation Error : FollowUser => e0001",
			"Validation Error : FollowUser => e0002",
			"Validation Error : FollowUser => e0003",
		};

		public FollowUserCommandValidator(IRepository<Following> followings)
		{
			RuleFor(x => x.FollowingId).NotEmpty().NotNull().WithMessage(messages[0]);
			RuleFor(x => x).Must( (x) => x.LoggedInUserId != x.FollowingId ).WithMessage(messages[1]);
			RuleFor(x => x).MustAsync(
				async (request, cancellationToken) =>
				{
					return !await followings
						.DbSet
						.AnyAsync(
							x => 
								x.FollowingId == request.FollowingId && 
								x.FollowerId == request.LoggedInUserId,
							cancellationToken
						);
				}
			).WithMessage(messages[2]);
		}

	}
}
