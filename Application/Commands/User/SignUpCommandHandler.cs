using Application.Configurations;
using Application.Dtos;
using Application.Dtos.SignUp;
using Application.Entities;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
	public class SignUpCommandHandler : IRequestHandler<SignUpRequestDto, AppResponseDto<SignUpResponseDto>>
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IRoleService _roles;

		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper, IRoleService roles)
		{
			_userManager = userManager;
			_mapper = mapper;
			_roles = roles;
		}

		public async Task<AppResponseDto<SignUpResponseDto>> Handle(SignUpRequestDto request, CancellationToken cancellationToken)
		{
			User user = new User(request.Email, request.UserName);
			user.AddRole(_roles.User.Id);
			var result = await _userManager.CreateAsync(user,request.Password);
			if (!result.Succeeded) throw new Exception(string.Join("\n",result.Errors.Select(x => x.Description)));
			return AppResponseDto<SignUpResponseDto>.Success(
				_mapper.Map<SignUpResponseDto>(user)
				);
		}
	}
}
