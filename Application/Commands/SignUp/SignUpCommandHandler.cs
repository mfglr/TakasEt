using Application.DomainEventModels;
using Application.Dtos.SignUp;
using Application.Entities;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands.SignUp
{
	public class SignUpCommandHandler : 
		IRequestHandler<
			SignUpCommandRequestDto,
			SignUpCommandResponseDto
		>
	{

		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork)
		{
			_userManager = userManager;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<SignUpCommandResponseDto> Handle(SignUpCommandRequestDto request, CancellationToken cancellationToken)
		{
			User user = new User(request.Email,request.UserName);
			var result = await _userManager.CreateAsync(user,request.Password);
			return _mapper.Map<SignUpCommandResponseDto>(user);
		}
	}
}
