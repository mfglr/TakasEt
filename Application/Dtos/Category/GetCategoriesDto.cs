using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetCategoriesDto : IPage, IRequest<AppResponseDto>
	{
		private int? _take;
		private int? _lastId;
		public int? Take => _take;
		public int? LastId => _lastId;

		public GetCategoriesDto(IQueryCollection collection)
		{
			_take = collection.ReadInt("take");
			_lastId = collection.ReadInt("lastId");
		}
	}
}
