using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Extentions;

namespace Models.Dtos
{
	public class GetUsersWhoLikedPostDto : IPage, IRequest<AppResponseDto>
	{
		private int? _take;
		private int? _lastId;

		public int? Take => _take;
		public int? LastId => _lastId;
		public string? Key { get; private set; }
		public int? PostId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetUsersWhoLikedPostDto(IQueryCollection collection)
        {
			_take = collection.ReadInt("take");
			_lastId = collection.ReadInt("lastId");
			PostId = collection.ReadInt("postId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");

        }
    }
}
