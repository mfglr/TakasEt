using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSwappedPosts : Pagination, IRequest<AppResponseDto>
	{
        public int UserId { get; set; }
        public GetSwappedPosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
