using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    
    public class GetPostImages : Pagination, IRequest<byte[]>
    {
        public int PostId { get; private set; }

        public GetPostImages(int postId,IQueryCollection collection) : base(collection)
        { 
            PostId = postId; 
        }
    }
}
