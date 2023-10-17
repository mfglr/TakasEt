using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUser,AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetUserQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetUser request, CancellationToken cancellationToken)
		{
			var user = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.Posts)
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
					CountOfPosts = x.Posts.Count(),
				})
				.SingleOrDefaultAsync(x => x.Id == request.UserId);
			if (user == null) throw new UserNotFoundException();
			return AppResponseDto.Success(user);
		}
	}
}
