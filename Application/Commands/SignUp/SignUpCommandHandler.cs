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
		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<SignUpCommandResponseDto> Handle(SignUpCommandRequestDto request, CancellationToken cancellationToken)
		{
			User user = _mapper.Map<User>(request);
			await _userManager.CreateAsync(user,request.Password);
			return _mapper.Map<SignUpCommandResponseDto>(user);
		}
	}
}
