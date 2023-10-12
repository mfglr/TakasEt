using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetFollowersByUserIdQueryHandler : IRequestHandler<GetFollowers, AppResponseDto>
    {

        private readonly IRepository<UserUserFollowing> _followings;

        public GetFollowersByUserIdQueryHandler(IRepository<UserUserFollowing> followings)
        {
            _followings = followings;
        }

        public async Task<AppResponseDto> Handle(GetFollowers request, CancellationToken cancellationToken)
        {
            var users = await _followings
                .DbSet
                .Where(x => x.FollowedId == request.UserId)
                .Include(x => x.Follower)
                .ThenInclude(x => x.Followeds)
                .Include(x => x.Follower)
                .ThenInclude(x => x.Followers)
                .Select(x => new UserResponseDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    Name = x.Follower.Name,
                    LastName = x.Follower.LastName,
                    Email = x.Follower.Email!,
                    UserName = x.Follower.UserName!,
                    CountOfFolloweds = x.Follower.Followeds.Count(),
                    CountOfFollowers = x.Follower.Followers.Count()
                })
                .ToListAsync();
            return AppResponseDto.Success(users);
        }
    }
}
