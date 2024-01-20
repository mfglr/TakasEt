using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetUsersWhoLikedPostQueryHandler : IRequestHandler<GetUsersWhoLikedPostDto, AppResponseDto>
	{
		private readonly IRepository<User> _users;
		public GetUsersWhoLikedPostQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetUsersWhoLikedPostDto request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.IncludeUser()
				.Include(x => x.LikedPosts)
				.Where( x => x.LikedPosts.Select(x => x.PostId).Contains((int)request.PostId!) )
				.ToPage(request)
				.ToUserResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
