using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    
    public class GetPostImages : Pagination, IRequest<byte[]>
    {
        public Guid PostId { get; private set; }

        public GetPostImages(Guid postId,IQueryCollection collection) : base(collection)
        { 
            PostId = postId; 
        }
    }
}
