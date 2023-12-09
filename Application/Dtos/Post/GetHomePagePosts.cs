using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetHomePagePosts : Pagination, IRequest<AppResponseDto>
	{
		public GetHomePagePosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
