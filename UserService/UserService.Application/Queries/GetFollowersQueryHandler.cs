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
    public class GetFollowersQueryHandler : IRequestHandler<GetFollowersDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetFollowersQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(GetFollowersDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var response = await _context
                .Users
                .Include(x => x.Images.FirstOrDefault(x => x.IsActive))
                .Where(x => x.UsersTheEntityFollowed.Any(x => x.FollowingId == loginUserId))
                .ToPage(x => x.CreatedDate, request)
                .ToUserResponseDto(loginUserId)
                .ToListAsync(cancellationToken);
            return new AppGenericSuccessResponseDto<List<UserResponseDto>>(response);
        }
    }
}
