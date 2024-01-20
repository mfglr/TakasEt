using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPageUsersDto : IPage, IRequest<AppResponseDto>
	{

		private int? _take;
		private int? _lastId;

		public int? Take => _take;
		public int? LastId => _lastId;
		public string? Key { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetSearchPageUsersDto(IQueryCollection collection)
		{
			_take = collection.ReadInt("take");
			_lastId = collection.ReadInt("lastId");
			Key = collection.ReadString("key");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
