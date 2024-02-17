using AuthService.Application.Dtos;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;

namespace AuthService.Application.Commands
{
    internal class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailDto, AppResponseDto>
    {
        private readonly UserManager<UserAccount> _userManager;

        public ConfirmEmailCommandHandler(UserManager<UserAccount> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppResponseDto> Handle(ConfirmEmailDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            
            if (user == null)
                return AppResponseDto.Fail("User was not found!");

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if (!result.Succeeded)
                return AppResponseDto.Fail(result.GetErrors());

            return AppResponseDto.Success();
        }
    }
}
