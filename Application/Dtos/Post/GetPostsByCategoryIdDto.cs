using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByCategoryIdDto : IPage, IRequest<AppResponseDto>
	{
        public int? CategoryId { get; set; }
		public int? Take { get; private set; }
		public int? LastId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetPostsByCategoryIdDto(IQueryCollection collection)
		{
			CategoryId = collection.ReadInt("categoryId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
