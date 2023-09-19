using Application.Configurations;
using Application.Dtos;
using Application.Dtos.User;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class AddFollowedCommandHandler : IRequestHandler<AddFollowedRequestDto, AppResponseDto>
	{


		private readonly IRepository<Following> _followeds;
		private readonly LoggedInUser _loggedInUser;
		public AddFollowedCommandHandler(IRepository<Following> followeds, LoggedInUser loggedInUser)
		{
			_followeds = followeds;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(AddFollowedRequestDto request, CancellationToken cancellationToken)
		{
			if (_loggedInUser.UserId == request.FollowedId) throw new FollowYourselfException();
			if(!await _followeds.DbSet.AnyAsync(x => x.FollowerId == _loggedInUser.UserId && x.FollowedId == request.FollowedId, cancellationToken))
				await _followeds.DbSet.AddAsync(new Following(_loggedInUser.UserId, request.FollowedId),cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
