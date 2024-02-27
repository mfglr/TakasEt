using UserService.Application.Dtos;
using UserService.Domain.UserAggregate;

namespace UserService.Application.Extentions
{
    public static class QueryableExtentions
    {
        public static IQueryable<UserResponseDto> ToUserResponseDto(this IQueryable<User> queryable, Guid logginUserId)
        {
            return queryable
                .Select(user => new UserResponseDto
                {
                    CreatedDate = user.CreatedDate,
                    RemovedDate = user.RemovedDate,
                    UpdatedDate = user.UpdatedDate,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Id = user.Id,
                    IsRemoved = user.IsRemoved,
                    LastName = user.LastName,
                    Name = user.Name,
                    NormalizedFullName = user.NormalizedFullName,
                    IsFollower = user.UsersTheEntityFollowed.Any(x => x.FollowingId == logginUserId),
                    IsFollowing = user.UsersWhoFollowedTheEntity.Any(x => x.FollowerId == logginUserId),
                    Images = user.Images.Select(image => new UserImageResponseDto()
                    {
                        Id = image.Id,
                        CreatedDate = image.CreatedDate,
                        IsRemoved = image.IsRemoved,
                        RemovedDate = image.RemovedDate,
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
