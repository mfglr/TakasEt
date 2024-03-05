using SharedLibrary.Dtos;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Extentions
{
    public static class QueryableExtentions
    {
        public static IQueryable<UserResponseDto> ToUserResponseDto(
            this IQueryable<User> queryable,
            Guid logginUserId
        )
        {
            return queryable
                .Select(user => new UserResponseDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Id = user.Id,
                    LastName = user.LastName,
                    Name = user.Name,
                    FullName = user.FullName,
                    IsFollower = user.UsersTheEntityFollowed.Any(x => x.FollowingId == logginUserId),
                    IsFollowing = user.UsersWhoFollowedTheEntity.Any(x => x.FollowerId == logginUserId),
                    CountOfFollowers = user.UsersWhoFollowedTheEntity.Count(),
                    CountOfFollowings = user.UsersTheEntityFollowed.Count(),
                    Images = user.Images.Where(x => x.IsActive).Select(image => new UserImageResponseDto()
                    {
                        Id = image.Id,
                        CreatedDate = image.CreatedDate,
                        UpdatedDate = image.UpdatedDate,
                        Extention = image.Extention,
                        ContainerName = image.ContainerName.Value,
                        IsActive = image.IsActive,
                        BlobName = image.BlobName,
                        AspectRatio = image.Dimension.AspectRatio,
                        Width = image.Dimension.Width,
                        Height = image.Dimension.Height,
                    })
                });
        }
    }
}
