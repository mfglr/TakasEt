using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.UnitOfWork;
using System.Data;
using System.Net;

namespace AuthService.Application.Commands
{
    public class LoginByRefreshTokenCommandHandler : IRequestHandler<LoginByRefreshTokenDto,IAppResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserAccount> _userManager;

        public LoginByRefreshTokenCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, UserManager<UserAccount> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<IAppResponseDto> Handle(LoginByRefreshTokenDto request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByIdAsync(request.UserId);
            if (
                user == null ||
                !await _tokenService.VerifyRefreshTokenAsync(user, request.Token)
            )
                throw new AppException("Invalid token!", HttpStatusCode.BadRequest);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            
            var refreshToken = await _tokenService.CreateRefreshTokenAsync(user.Id);
            var accessToken = await _tokenService.CreateAccessTokenAsync(user.Id);
            var response = new LoginResponseDto()
            {
                UserId = user.Id,
                AccessToken = accessToken.Value,
                ExpirationDateOfAccessToken = accessToken.ExpirationDate,
                RefreshToken = refreshToken.Value,
                ExpirationDateOfRefreshToken = refreshToken.ExpirationDate
            };

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return new AppGenericSuccessResponseDto<LoginResponseDto>(response);
        }
    }
}
