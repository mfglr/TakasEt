using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUserPosts : Page, IRequest<AppResponseDto>
	{
        public int UserId { get; private set; }

		public GetUserPosts(int userId,IQueryCollection collection) : base(collection)
		{
			UserId = userId;
		}
	}
}
