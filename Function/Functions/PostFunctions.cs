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
		
        [Function("add-post")]
        public async Task<AppResponseDto> AddPost([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _sender.Send( await req.ReadFromBodyAsync<AddPostRequestDto>() );
        }

		[Function("remove-post")]
		public async Task<AppResponseDto> RemovePost([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
		{
			return await _sender.Send( await req.ReadFromBodyAsync<RemovePostRequestDto>() );
		}
		
		[Function("get-post-by-id/{id}")]
		public async Task<AppResponseDto> GetPostById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid id
			)
		{
			return await _sender.Send(new GetPostByIdRequestDto(id));
		}
		
		[Function("like-post")]
		public async Task<AppResponseDto> LikePost(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<LikePostRequestDto>());
		}
		
		[Function("unlike-post")]
		public async Task<AppResponseDto> UnlikePost(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<UnlikePostRequestDto>());
		}

	}
}
