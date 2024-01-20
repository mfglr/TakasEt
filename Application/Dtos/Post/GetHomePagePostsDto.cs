using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetHomePagePostsDto : IPage, IRequest<AppResponseDto>
	{

		public int? Take { get; private set; }
		public int? LastId {  get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetHomePagePostsDto(IQueryCollection collection)
		{
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
		
	}
}
