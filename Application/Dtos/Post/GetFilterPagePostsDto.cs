using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFilterPagePostsDto : IPage, IRequest<AppResponseDto>
	{
		public IReadOnlyCollection<int>? CategoryIds { get; private set; }
		public string? Key { get; private set; }
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetFilterPagePostsDto(IQueryCollection collection)
		{
			CategoryIds = collection.ReadIntList("categoryIds");
			Key = collection.ReadString("key");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("ladtId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
