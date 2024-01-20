using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class UserCommendLikingController : ControllerBase
	{
		private readonly ISender _sender;

		public UserCommendLikingController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles ="user")]
		[HttpPost("user-comment-liking/like-comment")]
		public async Task<AppResponseDto> LikeComment(LikeCommentDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-comment-liking/unlike-comment")]
		public async Task<AppResponseDto> DislikeComment(DislikeCommentDto request)
		{
			return await _sender.Send(request);
		}

	}
}
