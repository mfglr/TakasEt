using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Extentions;

namespace Models.Dtos
{
	public class GetConversationsDto : IPage, IRequest<AppResponseDto>
	{

		public int? Take { get; private set; }
		public int? LastId {  get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetConversationsDto(IQueryCollection collection)
		{
			LoggedInUserId = collection.ReadInt("loggedInUserId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
		}


	}
}
