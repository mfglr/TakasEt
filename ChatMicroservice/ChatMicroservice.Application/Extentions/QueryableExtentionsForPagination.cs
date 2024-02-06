using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Domain.GroupAggregate;

namespace ChatMicroservice.Application.Extentions
{
	internal static class QueryableExtentionsForPagination
	{

		public static IQueryable<GroupResponseDto> ToGroupResponseDto(this IQueryable<Group> queryable,int loggedInUserId)
		{
			return queryable
				.Select(
					x => new GroupResponseDto()
					{
						Id = x.Id,
						CreatedDate = x.CreatedDate,
						UpdatedDate = x.UpdatedDate,
						RemovedDate = x.RemovedDate,
						Description = x.Description,
						Name = x.Name,
						NumberOfUnviewedMessages = x.Messages
							.Where(
								x =>
									!x.IsRemoved &&
									x.SenderId != loggedInUserId && 
									!x.UsersWhoViewedTheEntity.Any(x => x.UserId == loggedInUserId)
							)
							.Count()
					}
				);
		}

	}
}
