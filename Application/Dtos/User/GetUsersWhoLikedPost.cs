using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUsersWhoLikedPost : Pagination, IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

        public GetUsersWhoLikedPost(Guid postId,IQueryCollection collection) : base(collection)
        {
            PostId = postId;
        }
    }
}
