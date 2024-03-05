using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using UserService.Application.Dtos;
using UserService.Application.Extentions;
using UserService.Infrastructure;

namespace UserService.Application.Queries
{
    public class GetUsersByIdsQueryHandler : IRequestHandler<GetUsersByIdsDto, IAppResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _blockingService;

        public GetUsersByIdsQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor, BlockingService blockingService)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _blockingService = blockingService;
        }

        public async Task<IAppResponseDto> Handle(GetUsersByIdsDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var blockers = await _blockingService.GetBlockers();

            var userIds = request.Ids.Except(blockers);

            var users = await _context
                .Users
                .Where(x => userIds.Contains(x.Id))
                .ToUserResponseDto(loginUserId)
                .ToListAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<List<UserResponseDto>>(users);
        }
    }
}
