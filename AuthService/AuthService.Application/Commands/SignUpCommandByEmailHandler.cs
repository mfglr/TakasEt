using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Events;
using SharedLibrary.Exceptions;
using SharedLibrary.UnitOfWork;
using SharedLibrary.ValueObjects;
using System.Data;
using System.Net;

namespace AuthService.Application.Commands
{
    public class SignUpCommandByEmailHandler : IRequestHandler<SignUpByEmailDto, IAppResponseDto>
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public SignUpCommandByEmailHandler(UserManager<UserAccount> userManager, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<IAppResponseDto> Handle(SignUpByEmailDto request, CancellationToken cancellationToken)
        {
            
            var user = new UserAccount(request.Email);
            user.SetId();

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.BadRequest);

            result = await _userManager.AddToRoleAsync(user, Role.User.Name);
            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.BadRequest);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var refreshToken = await _tokenService.CreateRefreshTokenAsync(user.Id);
            var accessToken = await _tokenService.CreateAccessTokenAsync(user.Id);
            
            await _unitOfWork.CommitAsync(cancellationToken);

            var response = new LoginResponseDto()
            {
                UserId = user.Id,
                AccessToken = accessToken.Value,
                ExpirationDateOfAccessToken = accessToken.ExpirationDate,
                RefreshToken = refreshToken.Value,
                ExpirationDateOfRefreshToken = refreshToken.ExpirationDate
            };

            user.AddEvent(new UserAccountCreatedEvent() {
                Id = user.Id,
                Email = request.Email,
                UserName = user.UserName!
            });
            
            return new AppGenericSuccessResponseDto<LoginResponseDto>(response);
        }
    }
}
