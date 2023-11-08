using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetUsersWhoLikedPostQueryHandler : IRequestHandler<GetUsersWhoLikedPost, AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetUsersWhoLikedPostQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetUsersWhoLikedPost request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.Posts)
				.Include(x => x.LikedPosts)
				.Where(x => x.LikedPosts.Select(x => x.PostId).Contains(request.PostId))
				.ToPage(x => x.Id, request)
				.Select(x => new UserResponseDto()
				{
					Id = x.Id,
					CreatedDate = x.CreatedDate,
					UpdatedDate = x.UpdatedDate,
					Name = x.Name,
					LastName = x.LastName,
					Email = x.Email!,
					UserName = x.UserName!,
					CountOfFolloweds = x.Followeds.Count(),
					CountOfFollowers = x.Followers.Count(),
					CountOfPosts = x.Posts.Count()
				}).
				ToListAsync(cancellationToken);
			return AppResponseDto.Success(users);
		}
	}
}
