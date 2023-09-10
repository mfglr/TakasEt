using Application.Dtos;
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

		[Function("get-comment-by-id/{id}")]
		public async Task<CommentResponseDto> GetCommentById(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            Guid id)
		{
			return await _mediator.Send(new GetCommentByIdRequestDto(id));
		}

		[Function("add-comment")]
        public async Task<AddCommentResponseDto> AddComment([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _mediator.Send(await req.ReadFromBodyAsync<AddCommentRequestDto>());
        }

		[Function("remove-comment")]
		public async Task<NoContentResponseDto> RemoveComment(
            [HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req,
            Guid id)
		{
			return await _mediator.Send(new RemoveCommentRequestDto(id));
		}
	}
}
