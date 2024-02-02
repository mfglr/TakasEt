using MediatR;
using Microsoft.AspNetCore.Http;
using Common.Extentions;

namespace Models.Dtos
{
	public class GetCommentsDto : IPage, IRequest<AppResponseDto>
	{
		private int? _take;
		private int? _lastId;

		public int? Take => _take;
		public int? LastId => _lastId;
		public int? LoggedInUserId { get; private set; }

		public GetCommentsDto(IQueryCollection collection)
		{
			_take = collection.ReadInt("take");
			_lastId = collection.ReadInt("lastId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
