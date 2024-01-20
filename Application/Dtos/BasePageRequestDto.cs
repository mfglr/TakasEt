using Application.Extentions;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class BasePageRequestDto : BaseRequestDto
	{
		public int? Take { get; private set; }
		public int? LastId { get; private set; }

		public BasePageRequestDto(IQueryCollection collection) : base(collection)
		{
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
		}
	}
}
