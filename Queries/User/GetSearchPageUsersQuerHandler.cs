using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetSearchPageUsersQuerHandler : IRequestHandler<GetSearchPageUsersDto, AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetSearchPageUsersQuerHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetSearchPageUsersDto request, CancellationToken cancellationToken)
		{
			var normalizeKey = request.Key.CustomNormalize();
			
			if(normalizeKey == null || normalizeKey == "")
				return AppResponseDto.Success();

			var users = await _users
				.DbSet
				.AsNoTracking()
				.IncludeUser()
				.Where(
					user => 
						user.NormalizedFullName == null || 
						user.NormalizedFullName.Contains(normalizeKey) || 
						user.NormalizedUserName!.Contains(normalizeKey)
				)
				.ToPage(request)
				.ToUserResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
