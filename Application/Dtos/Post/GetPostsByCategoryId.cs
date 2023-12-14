using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByCategoryId : Pagination, IRequest<AppResponseDto>
	{
        public int CategoryId { get; set; }
        public GetPostsByCategoryId(IQueryCollection collection) : base(collection)
		{
		}
	}
}
