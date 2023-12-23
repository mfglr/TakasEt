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
			return await _sender.Send(new GetCommentsByPostId(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("comment/get-comments")]
		public async Task<AppResponseDto> GetComments()
		{
			return await _sender.Send(new GetComments(Request.Query));
		}


		[Authorize(Roles = "user")]
		[HttpGet("comment/get-children/{id}")]
		public async Task<AppResponseDto> GetChildren(int id)
		{
			return await _sender.Send(new GetChildren(id,Request.Query));
		}


		[Authorize(Roles = "user")]
		[HttpPost("comment/add-comment")]
		public async Task<AppResponseDto> AddComment(AddComment request)
		{
			return await _sender.Send(request);
		}
	}
}
