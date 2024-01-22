using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class CommnetController : ControllerBase
	{
		private readonly ISender _sender;

		public CommnetController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpGet("comment/get-comments-by-post-id/{postId}")]
		public async Task<AppResponseDto> GetCommentsByPostId(int postId)
		{
			return await _sender.Send(new GetCommentsByPostIdDto(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("comment/get-comments")]
		public async Task<AppResponseDto> GetComments()
		{
			return await _sender.Send(new GetCommentsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("comment/get-children")]
		public async Task<AppResponseDto> GetChildren()
		{
			return await _sender.Send(new GetChildrenDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpPost("comment/add-comment")]
		public async Task<AppResponseDto> AddComment(AddCommentDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpPut("comment/like-comment")]
		public async Task<AppResponseDto> LikeComment(LikeCommentDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpPut("comment/dislike-comment")]
		public async Task<AppResponseDto> DislikeComment(DislikeCommentDto request)
		{
			return await _sender.Send(request);
		}
	}
}
