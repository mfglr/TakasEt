using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPostListPagePosts : Page, IRequest<AppResponseDto>
	{
        public int PostId { get; set; }
        public GetSearchPostListPagePosts(IQueryCollection collection) : base(collection)
		{

		}
	}
}
