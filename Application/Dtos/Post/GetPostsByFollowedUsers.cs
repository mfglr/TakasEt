using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByFollowedUsers : Pagination, IRequest<AppResponseDto>
	{
        public GetPostsByFollowedUsers(IQueryCollection collection) : base(collection)
		{
		}
	}
}
