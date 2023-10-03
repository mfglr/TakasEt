using Application.Dtos;
using Function.Attributes;
using Function.Extentions;
using HttpMultipartParser;
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
		[Function("post/add-post")]
        public async Task<AppResponseDto> AddPost([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _sender.Send( new AddPostRequestDto(await MultipartFormDataParser.ParseAsync(req.Body)) );
        }

		[Authorize("user")]
		[Function("post/remove-post")]
		public async Task<AppResponseDto> RemovePost([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
		{
			return await _sender.Send( await req.ReadFromBodyAsync<RemovePostRequestDto>() );
		}

		[Authorize("user")]
		[Function("post/get-by-id/{id}")]
		public async Task<AppResponseDto> GetPostById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid id
			)
		{
			return await _sender.Send(new GetPostByIdRequestDto(id));
		}

		[Authorize("user")]
		[Function("post/like-post")]
		public async Task<AppResponseDto> LikePost(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<LikePostRequestDto>());
		}

		[Authorize("user")]
		[Function("post/unlike-post")]
		public async Task<AppResponseDto> UnlikePost(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<UnlikePostRequestDto>());
		}

		[Function("post/get-post-images-by-post-id/{postId}")]
		public async Task<byte[]> GetPostImagesByPostId(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid postId
		)
		{
			return await _sender.Send(new GetPostImagesByPostIdRequestDto(postId));
		}
	}
}
