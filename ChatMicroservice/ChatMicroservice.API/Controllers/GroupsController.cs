using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Dtos.Group;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

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

		[HttpPut]
		public async Task<AppResponseDto> LeaveGroup(LeaveGroupDto request,CancellationToken cancellationToken)
		{
			return await _sender.Send(request, cancellationToken);
		}

		[HttpPut]
		public async Task<AppResponseDto> RemoveUserFromGroup(RemoveUserFromGroupDto request,CancellationToken cancellationToken)
		{
			return await _sender.Send(request, cancellationToken);
		}


		[HttpGet("{userId}")]
		public async Task<AppResponseDto> GetGroupsWithUnviewedMessagesByUserId(int userId,CancellationToken cancellationToken)
		{
			var request = new GetGroupsWithUnviewedMessagesByUserIdDto()
			{
				UserId = userId,
				LastId = Request.Query.ReadInt("lastId"),
				Take = Request.Query.ReadInt("take")
			};
			return await _sender.Send(request, cancellationToken);
		}

		[HttpGet("{groupId}")]
		public async Task<AppResponseDto> GetGroupMessagesByGroupId(int groupId, CancellationToken cancellationToken)
		{
			var request = new GetGroupMessagesByGroupIdDto()
			{
				GroupId = groupId,
				UserId = Request.Query.ReadInt("userId"),
				LastId = Request.Query.ReadInt("lastId"),
				Take = Request.Query.ReadInt("take")
			};
			return await _sender.Send(request, cancellationToken);
		}

	}
}
