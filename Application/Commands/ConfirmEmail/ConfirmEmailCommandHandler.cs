using Application.Dtos;
using Application.Dtos.ConfirmEmail;
using Application.Entities;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommandRequestDto, NoContentResponseDto>
	{
		private readonly UserManager<User> _userManager;
		private readonly IUnitOfWork _unitOfWork;

		public ConfirmEmailCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
		}
			
		public async Task<NoContentResponseDto> Handle(ConfirmEmailCommandRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync<User>(x => x.UserName == request.UserName);
			user.ConfirmAccount();
			await _unitOfWork.CommitAsync();
			return new NoContentResponseDto();
		}
	}
}
