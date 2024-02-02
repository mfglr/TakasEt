using MediatR;
using Microsoft.AspNetCore.Http;
using Common.Extentions;

namespace Models.Dtos
{
	public class GetSearchPagePostsDto : IPage, IRequest<AppResponseDto>
	{
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }
		
		public GetSearchPagePostsDto(IQueryCollection collection)
		{
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}

	}
}
