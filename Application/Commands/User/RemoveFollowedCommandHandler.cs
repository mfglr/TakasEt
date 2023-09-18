using Application.Configurations;
using Application.Dtos;
using Application.Dtos.User;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveFollowedCommandHandler : IRequestHandler<RemoveFollowedRequestDto, AppResponseDto<NoContentResponseDto>>
	{

		private readonly IRepository<Following> _followings;
		private readonly LoggedInUser _user;

		public RemoveFollowedCommandHandler(IRepository<Following> followings, LoggedInUser user)
		{
			_followings = followings;
			_user = user;
		}

		public async Task<AppResponseDto<NoContentResponseDto>> Handle(RemoveFollowedRequestDto request, CancellationToken cancellationToken)
		{
			var record = await _followings.DbSet.SingleOrDefaultAsync(x => x.FollowerId == _user.UserId && x.FollowedId == request.FollowedId);
			if(record != null) _followings.DbSet.Remove(record);
			return AppResponseDto<NoContentResponseDto>.Success(new NoContentResponseDto());
		}
	}
}
