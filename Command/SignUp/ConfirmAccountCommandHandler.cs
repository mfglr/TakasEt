using Application.Dtos;
using Application.Dtos.SignUp;
using Application.Entities;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Command.SignUp
{
	public class ConfirmAccountCommandHandler : IRequestHandler<ConfirmAccountCommandRequestDto, NoContentResponseDto>
	{
		private readonly UserManager<User> _userManager;
		private readonly IUnitOfWork _unitOfWork;

		public ConfirmAccountCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_unitOfWork = unitOfWork;
		}

		public async Task<NoContentResponseDto> Handle(ConfirmAccountCommandRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync<User>(x => x.UserName == request.UserName);
			if (user != null && user.ConfirmationEmailToken == request.ConfimationToken) { 
				user.ConfirmAccount();
				await _unitOfWork.CommitAsync();
			}
			return new NoContentResponseDto();
		}
	}
}
