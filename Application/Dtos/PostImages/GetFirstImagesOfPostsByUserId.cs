using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    public class GetFirstImagesOfPostsByUserId : Pagination, IRequest<byte[]>
    {
        public int UserId { get; private set; }

        public GetFirstImagesOfPostsByUserId(int userId,IQueryCollection collection) : base(collection)
        { UserId = userId; }
    }
}
