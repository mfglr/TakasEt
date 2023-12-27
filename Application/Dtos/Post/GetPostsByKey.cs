using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByKey : Pagination, IRequest<AppResponseDto>
	{
        public string Key { get; set; }
        public GetPostsByKey(IQueryCollection collection) : base(collection)
		{
		}
	}
}
