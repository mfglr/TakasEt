using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPosts : Pagination, IRequest<AppResponseDto>
	{
		public GetPosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
