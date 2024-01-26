using Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iss_Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class TagController : ControllerBase
	{

		private readonly ISender _sender;
		public TagController(ISender sender) => _sender = sender;

		[Authorize(Roles = "user")]
		[HttpPost("tag/create")]
		public async Task<AppResponseDto> AddTag(AddTagDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpPut("tag/update")]
		public async Task<AppResponseDto> UpdateTag(UpdateTagDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("tag/delete/{id}")]
		public async Task<AppResponseDto> DeleteTag(int id)
		{
			return await _sender.Send(new DeleteTagDto(id));
		}

	}
}
