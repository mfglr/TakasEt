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
		public async Task<AppResponseDto> LikeComment(LikeComment request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-comment-liking/unlike-comment/{commentId}")]
		public async Task<AppResponseDto> UnlikeComment(Guid commentId)
		{
			return await _sender.Send(new UnlikeComment(commentId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-comment-liking/is-comment-liked/{commentId}")]
		public async Task<AppResponseDto> IsCommentLiked(Guid commentId)
		{
			return await _sender.Send(new IsCommentLiked(commentId));
		}

	}
}
