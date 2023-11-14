using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByUserId : Pagination, IRequest<AppResponseDto>
	{
        public int UserId { get; private set; }

		public GetPostsByUserId(int userId,IQueryCollection collection) : base(collection)
		{
			UserId = userId;
		}
	}
}
