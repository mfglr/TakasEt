using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUsersWhoLikedPost : Pagination, IRequest<AppResponseDto>
	{
        public int PostId { get; private set; }

        public GetUsersWhoLikedPost(int postId,IQueryCollection collection) : base(collection)
        {
            PostId = postId;
        }
    }
}
