using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostImagesDto : IPage, IRequest<AppResponseDto>
	{
		public int? PostId { get; private set; }
		public int? Take { get; private set; }
		public int? LastId { get; private set; }

		public GetPostImagesDto(IQueryCollection collection)
		{
			PostId = collection.ReadInt("postId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
		}

	}
}
