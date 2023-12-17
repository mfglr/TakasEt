using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFolloweds : Pagination,IRequest<AppResponseDto>
	{
        public int UserId { get; set; }
        public GetFolloweds(IQueryCollection collection) : base(collection) { }
	}
}
