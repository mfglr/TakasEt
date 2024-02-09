using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;

namespace Models.Dtos
{
	public class GetSearchPostListPagePostsDto : IPage, IRequest<AppResponseDto>
	{
        public int? PostId { get; private set; }
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetSearchPostListPagePostsDto(IQueryCollection collection)
		{
			PostId = collection.ReadInt("postId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
