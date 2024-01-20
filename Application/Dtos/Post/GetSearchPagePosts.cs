using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetSearchPagePosts : Page, IRequest<AppResponseDto>
	{
        public GetSearchPagePosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
