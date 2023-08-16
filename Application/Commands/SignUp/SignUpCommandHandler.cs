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
			User user = _mapper.Map<User>(request);
			var result = await _userManager.CreateAsync(user,request.Password);
			
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors.Select(x => x.Description)) {
					Console.WriteLine("hata " + error);
				}
				throw new Exception("Something went wrong! Please try again later.");
			}

			var domainEvent = new UserCreatedDomainEvent(user);
			user.AddDomainEvent(domainEvent);
			await _unitOfWork.CommitAsync();
			return _mapper.Map<SignUpCommandResponseDto>(user);
		}
	}
}
