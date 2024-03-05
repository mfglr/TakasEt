using AuthService.Application.Dtos;
using AuthService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace AuthService.Application.Queries
{
    public class GetBlockersQueryHandler : IRequestHandler<GetBlockersDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public GetBlockersQueryHandler(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(GetBlockersDto request, CancellationToken cancellationToken)
        {

            var logginUserId = _contextAccessor.HttpContext.GetLoginUserId()!;

            var blockers = 
                (
                    await _context
                        .Blockings
                        .Where(x => x.BlockedId == logginUserId)
                        .Select(x => x.BlockerId)
                        .ToListAsync(cancellationToken)
                )
                .Select(x => Guid.Parse(x))
                .ToList();

            return new AppGenericSuccessResponseDto<List<Guid>>(blockers);
        }
    }
}
