using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByKeyDto : IPage, IRequest<AppResponseDto>
	{
        public string? Key { get; set; }
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetPostsByKeyDto(IQueryCollection collection)
		{
			Key = collection.ReadString("key");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
