using AuthService.Web.Dtos;
using AuthService.Web.Services;
using MediatR;
using SharedLibrary.Dtos;
using System.Data;

namespace AuthService.Web.Commands
{
    internal class LoginByRefreshTokenCommandHandler : IRequestHandler<LoginByRefreshTokenDto, AppResponseDto>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;


        public LoginByRefreshTokenCommandHandler(IAuthenticationService authenticationService, IUnitOfWork unitOfWork)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppResponseDto> Handle(LoginByRefreshTokenDto request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            var response = await _authenticationService.LoginByRefreshTokenAsync(request.Token, request.UserId);
            await _unitOfWork.CommitAsync(cancellationToken);
            return AppResponseDto.Success(response);
        }
    }
}
