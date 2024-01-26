using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Extentions;

namespace Models.Dtos
{
	public class GetChildrenDto : IPage, IRequest<AppResponseDto>
	{
		private int? _take;
		private int? _lastId;
		public int? Take => _take;
		public int? LastId => _lastId;
		public int? ParentId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public GetChildrenDto(IQueryCollection collection)
		{
			_take = collection.ReadInt("take");
			_lastId = collection.ReadInt("lastId");
			ParentId = collection.ReadInt("parentId");
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
