using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameRequestDto, AppResponseDto<UserResponseDto>>
    {
        private readonly UserManager<User> _userManager;

        public GetUserByUserNameQueryHandler(UserManager<User> userManager)
        {
			_userManager = userManager;
        }

        public async Task<AppResponseDto<UserResponseDto>> Handle(GetUserByUserNameRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager
                .Users
                .Include (x => x.Followers)
                .Include(x => x.Followeds)
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
                    CountOfFollowers = x.Followers.Count()
                })
                .SingleOrDefaultAsync(x => x.UserName == request.UserName);
            if (user == null) throw new UserNotFoundException();
            return AppResponseDto<UserResponseDto>.Success(user);
        }
    }
}
