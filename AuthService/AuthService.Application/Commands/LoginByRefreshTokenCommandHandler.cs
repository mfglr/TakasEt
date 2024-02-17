using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Data;
using System.Net;

namespace AuthService.Application.Commands
{
    internal class LoginByRefreshTokenCommandHandler : IRequestHandler<LoginByRefreshTokenDto,AppResponseDto>
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

        public async Task<AppResponseDto> Handle(LoginByRefreshTokenDto request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (
                user == null ||
                !await _tokenService.VerifyRefreshTokenAsync(user, request.Token)
            )
                throw new AppException("Invalid token!", HttpStatusCode.BadRequest);
            var response = new LoginResponseDto()
            {
                UserId = user.Id,
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = await _tokenService.CreateRefreshTokenAsync(user),
            };
            
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return AppResponseDto.Success(response);
        }
    }
}
