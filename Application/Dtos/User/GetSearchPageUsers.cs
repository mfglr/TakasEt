using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPageUsers : Pagination, IRequest<AppResponseDto>
	{
        public string Key { get; set; }
        public GetSearchPageUsers(IQueryCollection collection) : base(collection)
		{
			Key = collection.Where(x => x.Key == "key").FirstOrDefault().Value.ToString(); ;
		}
	}
}
