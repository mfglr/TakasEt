using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPageUsers : Pagination, IRequest<AppResponseDto>
	{
        public string? Key { get; set; }
        public GetSearchPageUsers(IQueryCollection collection) : base(collection)
		{
			string key = collection.Where(x => x.Key == "take").FirstOrDefault().Value.ToString();
			if (key == "")
				Key = null;
			else
				Key = key;
		}
	}
}
