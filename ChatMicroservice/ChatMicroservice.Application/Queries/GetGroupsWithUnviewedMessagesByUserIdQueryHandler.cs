using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Extentions;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ChatMicroservice.Application.Queries
{

	/* 
		 * .Where(
		 *		x => 
		 *			// Groups that wanted must not be removed
		 *			!x.IsRemoved &&
		 *			
		 *			// The user (whose is request.UserId) must be a member of groups
		 *			x.Users.Any(x => x.UserId == request.UserId) &&
		 *			
		 *			// the groups must have messages with unviewed by the the user
		 *			// and not removed
		 *			// and its owner is not the user 
		 *			x.Messages.Any(
		 *				x => 
		 *					!x.IsRemoved &&
		 *					x.SenderId != request.UserId &&
		 *					!x.UsersWhoViewedTheEntity.Any(x => x.UserId == request.UserId)
		 *			)
		 *	)
		 *
		 */

	public class GetGroupsWithUnviewedMessagesByUserIdQueryHandler : IRequestHandler<GetGroupsWithUnviewedMessagesByUserIdDto, AppResponseDto>
	{
		private readonly ChatDbContext _chatDbContext;

		public GetGroupsWithUnviewedMessagesByUserIdQueryHandler(ChatDbContext chatDbContext)
		{
			_chatDbContext = chatDbContext;
		}

		public async Task<AppResponseDto> Handle(GetGroupsWithUnviewedMessagesByUserIdDto request, CancellationToken cancellationToken)
		{
			var groups = await _chatDbContext
				.Groups
				.AsNoTracking()
				.Where(
					x => 
						!x.IsRemoved &&
						x.Users.Any(x => x.UserId == request.UserId) &&
						x.Messages.Any(
							x => 
								!x.IsRemoved &&
								x.SenderId != request.UserId &&
								!x.UsersWhoViewedTheEntity.Any(x => x.UserId == request.UserId)
						)
				)
				.ToPage(request)
				.ToGroupResponseDto(request.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(groups);
		}
	}
}
