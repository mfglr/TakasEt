using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetNotSwappedPosts : Pagination, IRequest<AppResponseDto>
	{
        public int UserId { get; set; }
        public GetNotSwappedPosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
