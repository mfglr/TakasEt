using MediatR;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Application.Dtos
{
	public class GetFilterPagePosts : Pagination, IRequest<AppResponseDto>
	{
		public IEnumerable<int>? CategoryIds { get; set; }
		public string? Key { get; set; }

		public GetFilterPagePosts(IQueryCollection collection) : base(collection)
		{
			string categoryIds = collection.Where(x => x.Key == "categoryIds").FirstOrDefault().Value.ToString();
			string key = collection.Where(x => x.Key == "key").FirstOrDefault().Value.ToString();

			if (categoryIds != "") CategoryIds = categoryIds.Split(',').Select(x => int.Parse(x));
			else CategoryIds = null;

			if (key != "") Key = key;
			else Key = null;
		}
	}
}
