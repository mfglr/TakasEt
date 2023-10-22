using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Post
{
    public class GetPostsExceptRequesters : Pagination, IRequest<AppResponseDto>
    {
        public Guid PostId { get; private set; }

        public GetPostsExceptRequesters(Guid postId,IQueryCollection collection) : base(collection)
        { 
            PostId = postId; 
        }
    }
}
