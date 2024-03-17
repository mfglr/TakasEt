using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using System.Net;
using UserService.Application.Dtos;
using UserService.Application.Extentions;
using UserService.Infrastructure;

namespace UserService.Application.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly BlockingService _blockingService;

        public GetUserByIdQueryHandler(IHttpContextAccessor contextAccessor, AppDbContext context, BlockingService blockingService)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _blockingService = blockingService;
        }

        public async Task<IAppResponseDto> Handle(GetUserByIdDto request, CancellationToken cancellationToken)
        {
            await _blockingService.ThrowExceptionIfBlockerOfBlockedAsync(request.UserId.ToString());
            
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            
            var user = await _context
                .Users
                .ToUserResponseDto(loginUserId)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user == null)
                throw new AppException("User was not found!", HttpStatusCode.NotFound);

            return new AppGenericSuccessResponseDto<UserResponseDto>(user);
        }
    }
}
