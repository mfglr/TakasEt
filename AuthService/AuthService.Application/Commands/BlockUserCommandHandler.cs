using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Data;
using System.Net;

namespace AuthService.Application.Commands
{
    public class BlockUserCommandHandler : IRequestHandler<BlockUserDto,IAppResponseDto>
    {

        private readonly UserManager<UserAccount> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingService _accessTokenReader;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public BlockUserCommandHandler(UserManager<UserAccount> userManager, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork, ITokenService tokenService, BlockingService accessTokenReader)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _accessTokenReader = accessTokenReader;
        }

        public async Task<IAppResponseDto> Handle(BlockUserDto request, CancellationToken cancellationToken)
        {
            string loginUserId = _contextAccessor.HttpContext.GetLoginUserId()!;
            var blockedUser = await _userManager
                .Users
                .Include(x => x.UsersWhoBlockedTheEntity.Where(x => x.BlockerId == loginUserId))
                .FirstOrDefaultAsync(x => x.Id == request.UserId,cancellationToken) ??
                throw new AppException("User was not found", HttpStatusCode.NotFound);

            await _accessTokenReader.ThrowExceptionIfBlockerAsync(request.UserId);
            await _accessTokenReader.ThrowExceptionIfBlockedAsync(request.UserId);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            blockedUser.Block(loginUserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var refreshToken = await _tokenService.CreateRefreshTokenAsync(loginUserId);
            var accessToken = await _tokenService.CreateAccessTokenAsync(loginUserId,request.TimeZone,request.Offset);
            var response = new LoginResponseDto()
            {
                UserId = loginUserId,
                AccessToken = accessToken.Value,
                ExpirationDateOfAccessToken = accessToken.ExpirationDate,
                RefreshToken = refreshToken.Value,
                ExpirationDateOfRefreshToken = refreshToken.ExpirationDate
            };

            return new AppGenericSuccessResponseDto<LoginResponseDto>(response);
        }

    }
}
