using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Commands
{
	public class ViewPostCommandHandler : IRequestHandler<ViewPost, AppResponseDto>
	{
		private readonly IRepository<UserPostViewing> _viewings;
		private readonly LoggedInUser _loggedInUser;

		public ViewPostCommandHandler(IRepository<UserPostViewing> viewings, LoggedInUser loggedInUser)
		{
			_viewings = viewings;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(ViewPost request, CancellationToken cancellationToken)
		{
			var record = await _viewings.DbSet.AnyAsync(
				x => x.UserId == _loggedInUser.UserId && request.PostId == x.PostId
			);
			if(!record)
				await _viewings.DbSet.AddAsync(
					new UserPostViewing(_loggedInUser.UserId, request.PostId)
				);
			return AppResponseDto.Success();
		}
	}
}
