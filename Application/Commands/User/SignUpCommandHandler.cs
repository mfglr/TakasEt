using Application.Dtos;
using Application.Dtos.SignUp;
using Application.Entities;
using Application.Extentions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
	public class SignUpCommandHandler : IRequestHandler<SignUpRequestDto, AppResponseDto<SignUpResponseDto>>
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<AppResponseDto<SignUpResponseDto>> Handle(SignUpRequestDto request, CancellationToken cancellationToken)
		{
			User user = new User(request.Email, request.UserName);
			var result = await _userManager.CreateAsync(user,request.Password);
			if (!result.Succeeded) throw new Exception(string.Join("\n",result.Errors.Select(x => x.Description)));
			return AppResponseDto<SignUpResponseDto>.Success(_mapper.Map<SignUpResponseDto>(user));
		}
	}
}
