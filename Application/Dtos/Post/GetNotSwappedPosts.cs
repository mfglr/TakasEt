using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetNotSwappedPosts : Page, IRequest<AppResponseDto>
	{
        public int UserId { get; set; }
        public GetNotSwappedPosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
