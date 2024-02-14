using AuthService.Web.DomainEvents.Models;
using AuthService.Web.Dtos;
using AuthService.Web.Entities;
using AuthService.Web.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Web.Commands
{
    public class SignUpCommandByEmailHandler : IRequestHandler<SignUpByEmailDto, AppResponseDto>
    {
        private readonly UserManager<User> _userManager;

        public SignUpCommandByEmailHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppResponseDto> Handle(SignUpByEmailDto request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email,request.UserName);
            user.AddDomainEvent(new UserCreatedByEmailEvent(user));

            var result = await _userManager.CreateAsync( user,request.Password );

            if(!result.Succeeded)
                throw new AppException(result.GetErrors(),HttpStatusCode.BadRequest);



            return AppResponseDto.Success();
        }
    }
}
