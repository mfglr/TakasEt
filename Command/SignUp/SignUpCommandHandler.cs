using Application.Dtos;
using AutoMapper;
using Dto.SignUp;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Model.Entities;

namespace Command.SignUp
{
	public class SignUpCommandHandler : 
		IRequestHandler<
			SignUpCommandRequestDto,
			CustomResponseDto<SignUpCommandResponseDto>
		>
	{

		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<CustomResponseDto<SignUpCommandResponseDto>> Handle(SignUpCommandRequestDto request, CancellationToken cancellationToken)
		{
			User user = _mapper.Map<User>(request);
			var result = await _userManager.CreateAsync(user);
			if (result.Succeeded)
			{
				return CustomResponseDto<SignUpCommandResponseDto>.Success(_mapper.Map<SignUpCommandResponseDto>(user));
			}
			CustomResponseDto< >
			foreach (var item in result.Errors) {
				
			}
		}
	}
}
