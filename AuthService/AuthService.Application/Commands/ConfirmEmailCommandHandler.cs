using AuthService.Application.Dtos;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Application.Commands
{
    internal class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailDto,IAppResponseDto>
    {
        private readonly UserManager<UserAccount> _userManager;

        public ConfirmEmailCommandHandler(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IAppResponseDto> Handle(ConfirmEmailDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
                throw new AppException("User was not found!", HttpStatusCode.NotFound);

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
                throw new AppException(result.GetErrors(), HttpStatusCode.NotFound);

            return new AppSuccessResponseDto();
        }
    }
}
