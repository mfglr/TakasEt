using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Post
{
	public class GetPostsExceptRequesters : Pagination, IRequest<AppResponseDto>
    {
        public int PostId { get; private set; }

        public GetPostsExceptRequesters(int postId,IQueryCollection collection) : base(collection)
        { 
            PostId = postId; 
        }
    }
}
