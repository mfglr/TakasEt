using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetSearchPageUsersQuerHandler : IRequestHandler<GetSearchPageUsers, AppResponseDto>
	{
		private readonly IRepository<User> _users;
		private readonly LoggedInUser _loggedInUser;

		public GetSearchPageUsersQuerHandler(IRepository<User> users, LoggedInUser loggedInUser)
		{
			_users = users;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetSearchPageUsers request, CancellationToken cancellationToken)
		{
			var normalizeKey = request.Key?.CustomNormalize();
			var users = await _users
				.DbSet
				.IncludeUser()
				.Where(
					user => (
						normalizeKey == null ||
						user.NormalizedFullName.Contains(normalizeKey) ||
						user.NormalizedUserName!.Contains(normalizeKey)
					)
				)
				.ToPage(request)
				.ToUserResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
