using Application.Dtos;
using Function.Attributes;
using Function.Extentions;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class CommentFuctions
    {
        private readonly IMediator _mediator;

        public CommentFuctions(IMediator mediator)
        {
            _mediator = mediator;
        }

		[Authorize("user")]
		[Function("get-comment-by-id/{id}")]
		public async Task<AppResponseDto> GetCommentById(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            Guid id)
		{
			return await _mediator.Send(new GetCommentByIdRequestDto(id));
		}

		[Authorize("user")]
		[Function("add-comment")]
        public async Task<AppResponseDto> AddComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _mediator.Send(await req.ReadFromBodyAsync<AddCommentRequestDto>());
        }

		[Authorize("user")]
		[Function("remove-comment")]
		public async Task<AppResponseDto> RemoveComment(
            [HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req,
            Guid id)
		{
			return await _mediator.Send(new RemoveCommentRequestDto(id));
		}
	}
}
