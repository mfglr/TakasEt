using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Extentions;

namespace Models.Dtos
{
	public class GetCommentsByPostIdDto : IPage, IRequest<AppResponseDto>
	{
		public int? PostId { get; private set; }
		public int? Take { get; private set; }
		public int? LastId {  get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetCommentsByPostIdDto(IQueryCollection collection)
		{
			PostId = collection.ReadInt("postId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
