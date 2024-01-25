using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Iss_Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly ISender _sender;

		public RoleController(ISender sender)
		{
			_sender = sender;
		}


		[Authorize(Roles = "admin")]
		[HttpPost("role/create")]
		public async Task<AppResponseDto> AddRole(AddRoleDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "admin")]
		[HttpPut("role/update")]
		public async Task<AppResponseDto> UpdateRole(UpdateRoleDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "admin")]
		[HttpDelete("role/delete/{id}")]
		public async Task<AppResponseDto> DeleteRole(int id)
		{
			return await _sender.Send(new DeleteRoleDto(id));
		}

	}
}
