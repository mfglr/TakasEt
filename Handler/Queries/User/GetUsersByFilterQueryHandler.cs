
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetUsersByFilterQueryHandler : IRequestHandler<GetUsersByFilter, AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetUsersByFilterQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetUsersByFilter request, CancellationToken cancellationToken)
		{
			var users = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.Posts)
				.Where(
					x => 
						x.Name.ToLower().Contains(request.Key) && 
						x.Gender == request.Gender
				)
				.OrderBy(x => x.CreatedDate)
				.Take(10)
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
				})
				.ToListAsync();
			return AppResponseDto.Success(users);
		}
	}
}
