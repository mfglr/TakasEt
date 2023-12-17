using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFollowers : Pagination, IRequest<AppResponseDto>
	{
        public int UserId { get; set; }
        public GetFollowers(IQueryCollection collection) : base(collection)
		{
		}
	}
}
