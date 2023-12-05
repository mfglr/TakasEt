using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUser,AppResponseDto>
	{
		private readonly IRepository<User> _users;
		private readonly LoggedInUser _loggedInUser;

		public GetUserQueryHandler(IRepository<User> users, LoggedInUser loggedInUser)
		{
			_users = users;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetUser request, CancellationToken cancellationToken)
		{
			var user = await _users
				.DbSet
				.AsNoTracking()
				.Include(x => x.Followers)
				.Include(x => x.Followeds)
				.Include(x => x.ProfileImages)
				.ToUserResponseDto(_loggedInUser.UserId)
				.SingleOrDefaultAsync(x => x.Id == request.UserId);
			if (user == null) throw new UserNotFoundException();
			return AppResponseDto.Success(user);
		}
	}
}
