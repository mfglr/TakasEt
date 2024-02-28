using AuthService.Application.Dtos;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Events;
using SharedLibrary.Exceptions;
using SharedLibrary.UnitOfWork;
using SharedLibrary.ValueObjects;
using System.Net;

namespace AuthService.Application.Commands
{
    public class SignUpCommandByEmailHandler : IRequestHandler<SignUpByEmailDto, IAppResponseDto>
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IUnitOfWork _unitOfWork;


        public SignUpCommandByEmailHandler(UserManager<UserAccount> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(SignUpByEmailDto request, CancellationToken cancellationToken)
        {
            
            var user = new UserAccount(request.Email);
            user.SetId();

            await _unitOfWork.BeginTransactionAsync(cancellationToken: cancellationToken);
            
            var result = await _userManager.CreateAsync( user,request.Password );
            if(!result.Succeeded)
                throw new AppException(result.GetErrors(),HttpStatusCode.BadRequest);
            
            result = await _userManager.AddToRoleAsync(user, Role.User.Name);
            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.BadRequest);
            
            await _unitOfWork.CommitAsync(cancellationToken: cancellationToken);

            user.AddEvent(new UserAccountCreatedEvent() { Id = user.Id, Email = request.Email });
            
            return new AppSuccessResponseDto();
        }
    }
}
