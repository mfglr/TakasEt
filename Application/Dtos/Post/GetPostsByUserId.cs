using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByUserId : Pagination, IRequest<AppResponseDto>
	{
        public Guid UserId { get; private set; }

		public GetPostsByUserId(Guid userId,IQueryCollection collection) : base(collection)
		{
			UserId = userId;
		}
	}
}
