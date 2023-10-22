using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    public class GetFirstImagesOfPostsByUserId : Pagination, IRequest<byte[]>
    {
        public Guid UserId { get; private set; }

        public GetFirstImagesOfPostsByUserId(Guid userId,IQueryCollection collection) : base(collection)
        { UserId = userId; }
    }
}
