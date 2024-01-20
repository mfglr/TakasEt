using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetHomePagePosts : Page, IRequest<AppResponseDto>
	{
		public GetHomePagePosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
