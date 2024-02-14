using AuthService.Api.DomainEvents.Models;
using AuthService.Api.Dtos;
using AuthService.Api.Entities;
using AuthService.Api.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Api.Commands
{
    public class SignUpCommandByEmailHandler : IRequestHandler<SignUpByEmailDto, AppResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpCommandByEmailHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppResponseDto> Handle(SignUpByEmailDto request, CancellationToken cancellationToken)
        {
            var user = new User(request.Email,request.UserName);
            user.AddDomainEvent(new UserCreatedByEmailEvent(user));

            var result = await _userManager.CreateAsync( user,request.Password );

            if(!result.Succeeded)
                throw new AppException(result.GetErrors(),HttpStatusCode.BadRequest);

            await _unitOfWork.CommitAsync(cancellationToken);

            return AppResponseDto.Success();
        }
    }
}
