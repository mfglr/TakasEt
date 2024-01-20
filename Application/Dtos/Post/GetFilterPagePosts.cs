using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFilterPagePosts : Page, IRequest<AppResponseDto>
	{
		public IEnumerable<int>? CategoryIds { get; set; }
		public string? Key { get; set; }

		public GetFilterPagePosts(IQueryCollection collection) : base(collection)
		{
			CategoryIds = collection.ReadIntList("categoryIds");
			Key = collection.ReadString("key");
		}
	}
}
