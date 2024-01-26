using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

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
				.Include(x => x.PostsLiked)
				.Where( x => x.PostsLiked.Select(x => x.PostId).Contains((int)request.PostId!) )
				.ToPage(request)
				.ToUserResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
