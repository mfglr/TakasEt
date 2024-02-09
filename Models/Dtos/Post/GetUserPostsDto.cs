using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Extentions;

namespace Models.Dtos
{
	public class GetUserPostsDto : IPage, IRequest<AppResponseDto>
	{
        public int? UserId { get; private set; }
		public int? Take { get; private set; }
		public int? LastId {  get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetUserPostsDto(IQueryCollection collection)
		{
			UserId = collection.ReadInt("userId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
