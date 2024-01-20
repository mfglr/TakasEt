using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUserDto : BaseRequestDto, IRequest<AppResponseDto>
    {
        public int? UserId { get; private set; }

        public GetUserDto(IQueryCollection collection) : base(collection)
        {
            UserId = collection.ReadInt("userId");
        }
    }
}
