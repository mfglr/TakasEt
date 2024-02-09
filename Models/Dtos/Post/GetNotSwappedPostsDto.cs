using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;

namespace Models.Dtos
{
	public class GetNotSwappedPostsDto : IPage, IRequest<AppResponseDto>
	{
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetNotSwappedPostsDto(IQueryCollection collection)
		{
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
