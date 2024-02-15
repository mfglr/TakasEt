using AuthService.Web.Dtos;
using AuthService.Web.Services;
using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Web.Commands
{
    internal class LoginByEmailCommandHandler : IRequestHandler<LoginByEmailDto, AppResponseDto>
    {

        private readonly IAuthenticationService _authenticationService;
        private readonly IUnitOfWork _unitOfWork;


        public LoginByEmailCommandHandler(IAuthenticationService authenticationService, IUnitOfWork unitOfWork)
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppResponseDto> Handle(LoginByEmailDto request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted,cancellationToken);
            var response = await _authenticationService.LoginByEmailAsync(
                    request.Email,
                    request.Password
                );
            await _unitOfWork.CommitAsync(cancellationToken);
            return AppResponseDto.Success(response);
        }
    }
}
