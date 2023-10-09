using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class PostPostRequestingController : ControllerBase
	{
		private readonly ISender _sender;

		public PostPostRequestingController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("post-post-requesting/add-swap-requests")]
		public async Task<AppResponseDto> AddSwapRequests(AddSwapRequestsRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-post-requesting/get-requester-posts-by-post-id/{postId}")]
		public async Task<AppResponseDto> GetRequesterPostsByPostId(Guid postId)
		{
			return await _sender.Send(new GetRequesterPostsRequestDto(postId));
		}
	}
}
