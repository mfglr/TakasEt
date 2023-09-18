using Application.Dtos;
using Function.Attributes;
using Function.Extentions;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class PostFunctions
    {
        private readonly ISender _sender;

        public PostFunctions(ISender sender)
        {
            _sender = sender;
        }

		[Authorize("user")]
        [Function("add-post")]
        public async Task<AppResponseDto<AddPostResponseDto>> AddPost([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _sender.Send( await req.ReadFromBodyAsync<AddPostRequestDto>() );
        }

		[Authorize("user")]
		[Function("remove-post")]
		public async Task<AppResponseDto<NoContentResponseDto>> RemovePost([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
		{
			return await _sender.Send( await req.ReadFromBodyAsync<RemovePostRequestDto>() );
		}

		[Authorize("user")]
		[Function("get-post-by-id/{id}")]
		public async Task<AppResponseDto<PostResponseDto>> GetPostById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid id
			)
		{
			return await _sender.Send(new GetPostByIdRequestDto(id));
		}

		[Authorize("user")]
		[Function("like-post")]
		public async Task<AppResponseDto<NoContentResponseDto>> LikePost(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<LikePostRequestDto>());
		}

		[Authorize("user")]
		[Function("unlike-post")]
		public async Task<AppResponseDto<NoContentResponseDto>> UnlikePost(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<UnlikePostRequestDto>());
		}

	}
}
