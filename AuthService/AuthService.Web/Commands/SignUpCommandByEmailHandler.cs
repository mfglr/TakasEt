using AuthService.Web.Dtos;
using AuthService.Web.Entities;
using AuthService.Web.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.IntegrationEvents;
using System.Net;
using System.Text;

namespace AuthService.Web.Commands
{
    internal class SignUpCommandByEmailHandler : IRequestHandler<SignUpByEmailDto, AppResponseDto>
    {
        private readonly UserManager<UserAccount> _userManager;

        public SignUpCommandByEmailHandler(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppResponseDto> Handle(SignUpByEmailDto request, CancellationToken cancellationToken)
        {
            var user = new UserAccount(request.Email,request.UserName);
            var result = await _userManager.CreateAsync( user,request.Password );
            
            if(!result.Succeeded)
                throw new AppException(result.GetErrors(),HttpStatusCode.BadRequest);

            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            user.AddIntegrationEvent(
                new User_Created_SendEmailConfirmationMail_Event()
                {
                    ReceiverEmail = user.Email!,
                    Token = token64,
                    UserId = user.Id
                }
            );

            return AppResponseDto.Success();
        }
    }
}
