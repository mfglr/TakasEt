using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Dtos.Group;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace ChatMicroservice.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class GroupsController : ControllerBase
	{

		private readonly ISender _sender;

		public GroupsController(ISender sender)
		{
			_sender = sender;
		}

		[HttpPost]
		public async Task<AppResponseDto> CreateGroup(CreateGroupDto request,CancellationToken cancellationToken)
		{
			return await _sender.Send(request,cancellationToken);
		}

		[HttpPut]
		public async Task<AppResponseDto> MakeRequestToJoinGroup(MakeRequestToJoinGroupDto request,CancellationToken cancellationToken)
		{
			return await _sender.Send(request, cancellationToken);
		}

		[HttpPut]
		public async Task<AppResponseDto> ApproveRequestToJoinGroup(ApproveRequestToJoinGroupDto request,CancellationToken cancellationToken)
		{
			return await _sender.Send(request, cancellationToken);
		}


	}
}
