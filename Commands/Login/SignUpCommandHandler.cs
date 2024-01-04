using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Commands
{
    public class SignUpCommandHandler : IRequestHandler<SignUp, AppResponseDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepository<UserRole> _userRoles;
        private readonly Configuration _configuration;
        public SignUpCommandHandler(UserManager<User> userManager, IMapper mapper, IRepository<UserRole> userRoles, Configuration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRoles = userRoles;
            _configuration = configuration;
        }

        public async Task<AppResponseDto> Handle(SignUp request, CancellationToken cancellationToken)
        {
            User user = new User(request.Email, request.UserName);
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors.Select(x => x.Description)));
            await _userRoles.DbSet.AddAsync(new UserRole(user.Id, _configuration.Roles.User.Id));
            return AppResponseDto.Success(_mapper.Map<UserResponseDto>(user));
        }
    }
}
