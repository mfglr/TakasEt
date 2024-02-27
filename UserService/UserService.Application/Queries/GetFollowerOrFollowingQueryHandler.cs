using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using UserService.Application.Dtos;
using UserService.Application.Extentions;
using UserService.Infrastructure;

namespace UserService.Application.Queries
{
    public class GetFollowerOrFollowingQueryHandler : IRequestHandler<GetFollowersOrFollowingsDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public GetFollowerOrFollowingQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(GetFollowersOrFollowingsDto request, CancellationToken cancellationToken)
        {
            var logginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var response = await _context
                .Users
                .Include(x => x.Images.FirstOrDefault(x => x.IsActive))
                .Where(
                    x =>
                        x.UsersWhoFollowedTheEntity.Any(x => x.FollowerId == logginUserId) ||
                        x.UsersTheEntityFollowed.Any(x => x.FollowingId == logginUserId)
                )
                .ToPage(request)
                .ToUserResponseDto(logginUserId)
                .ToListAsync(cancellationToken);
            return new AppGenericSuccessResponseDto<List<UserResponseDto>>(response);
        }
    }
}
