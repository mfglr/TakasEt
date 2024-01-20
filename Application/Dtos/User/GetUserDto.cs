using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUserDto :  IRequest<AppResponseDto>
    {
        public int? LoggedInUserId { get; private set; }

        public GetUserDto(IQueryCollection collection)
        {
			LoggedInUserId = collection.ReadInt("loggedInUserId");
        }
    }
}
