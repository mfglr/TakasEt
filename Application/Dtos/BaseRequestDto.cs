using Application.Extentions;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class BaseRequestDto
	{
		public int? LoggedInUserId { get; private set; }
		public BaseRequestDto(IQueryCollection collection)
		{
			LoggedInUserId = collection.ReadInt("loggedInUserId");
		}
	}
}
