using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
    public class GetFollowedsByUserIdQueryHandler : IRequestHandler<GetFolloweds, AppResponseDto>
    {
        private readonly IRepository<UserUserFollowing> _followings;
        public GetFollowedsByUserIdQueryHandler(IRepository<UserUserFollowing> followings)
        {
            _followings = followings;
        }

        public async Task<AppResponseDto> Handle(GetFolloweds request, CancellationToken cancellationToken)
        {
            var users = await _followings
                .DbSet
				.AsNoTracking()
				.Where(x => x.FollowerId == request.UserId)
                .Include(x => x.Followed)
                .ThenInclude(x => x.Followeds)
                .Include(x => x.Followed)
                .ThenInclude(x => x.Followers)
                .Select(x => new UserResponseDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Name = x.Followed.Name,
                    LastName = x.Followed.LastName,
                    Email = x.Followed.Email!,
                    UserName = x.Followed.UserName!,
                    CountOfFolloweds = x.Followed.Followeds.Count(),
                    CountOfFollowers = x.Followed.Followers.Count()
                })
                .ToListAsync();
            return AppResponseDto.Success(users);
        }
    }
}
