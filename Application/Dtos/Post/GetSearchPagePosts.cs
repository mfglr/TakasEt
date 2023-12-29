using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPagePosts : Pagination, IRequest<AppResponseDto>
	{
        public string? Key { get; set; }
        public GetSearchPagePosts(IQueryCollection collection) : base(collection)
		{
			string key = collection.Where(x => x.Key == "key").FirstOrDefault().Value.ToString();
			if (key == "") Key = null;
			else Key = key;
		}
	}
}
