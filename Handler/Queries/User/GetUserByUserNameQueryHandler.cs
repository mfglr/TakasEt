using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserName, AppResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly LoggedInUser _loggedInUser;

		public GetUserByUserNameQueryHandler(UserManager<User> userManager, LoggedInUser loggedInUser)
		{
			_userManager = userManager;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetUserByUserName request, CancellationToken cancellationToken)
        {
            var user = await _userManager
                .Users
				.AsNoTracking()
				.Include (x => x.Followers)
                .Include(x => x.Followeds)
				.Include(x => x.ProfileImages)
				.ToUserResponseDto(_loggedInUser.UserId)
                .SingleOrDefaultAsync(x => x.UserName == request.UserName);
            if (user == null) throw new UserNotFoundException();
            return AppResponseDto.Success(user);
        }
    }
}
