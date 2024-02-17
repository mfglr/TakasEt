using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Application.Commands
{
    internal class LoginByEmailCommandHandler : IRequestHandler<LoginByEmailDto, AppResponseDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserAccount> _userManager;

        public LoginByEmailCommandHandler(IUnitOfWork unitOfWork, UserManager<UserAccount> userManager, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AppResponseDto> Handle(LoginByEmailDto request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted,cancellationToken);

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (
                user == null ||
                !await _userManager.CheckPasswordAsync(user, request.Password)
            )
                throw new AppException("Email or password wrong!", HttpStatusCode.BadRequest);

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
