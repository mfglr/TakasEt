using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetHomePosts : Pagination, IRequest<AppResponseDto>
	{
		public GetHomePosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
