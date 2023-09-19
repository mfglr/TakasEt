using Application.Dtos;
using Application.Dtos.SignUp;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Commands
{
	public class SignUpCommandHandler : IRequestHandler<SignUpRequestDto, AppResponseDto>
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IRepository<UserRole> _userRoles;
		private readonly IRoleService _roleService;

		public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper, IRepository<UserRole> userRoles, IRoleService roleService)
		{
			_userManager = userManager;
			_mapper = mapper;
			_userRoles = userRoles;
			_roleService = roleService;
		}

		public async Task<AppResponseDto> Handle(SignUpRequestDto request, CancellationToken cancellationToken)
		{
			User user = new User(request.Email, request.UserName);
			var result = await _userManager.CreateAsync(user,request.Password);
			if (!result.Succeeded) throw new Exception(string.Join("\n",result.Errors.Select(x => x.Description)));
			await _userRoles.DbSet.AddAsync(new UserRole(user.Id, _roleService.User.Id));
			return AppResponseDto.Success(
				_mapper.Map<SignUpResponseDto>(user)
				);
		}
	}
}
