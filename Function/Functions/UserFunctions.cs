using Application.Dtos;
using Function.Attributes;
using Function.Extentions;
using HttpMultipartParser;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class UserFunctions
	{
		private readonly ISender _sender;

		public UserFunctions(ISender sender)
		{
			_sender = sender;
		}

		[Function("sing-up")]
		public async Task<AppResponseDto> SingUp([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<SignUpRequestDto>());
		}

		[Function("login")]
		public async Task<AppResponseDto> Login([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<LoginRequestDto>());
		}

		[Authorize("user")]
		[Function("user/get-user-by-username/{username}")]
		public async Task<AppResponseDto> GetUser(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			string username
		)
		{
			return await _sender.Send(new GetUserByUserNameRequestDto(username));
		}

		[Authorize("user")]
		[Function("user/remove-user/{id}")]
		public async Task<AppResponseDto> RemoveUser(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req,
			Guid id
		)
		{
			return await _sender.Send(new RemoveUserRequestDto(id));
		}


		[Authorize("user")]
		[Function("user/get-followeds-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetFollowedsById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid userId
		)
		{
			return await _sender.Send(new GetFollowedsByUserIdRequestDto(userId));
		}

		[Authorize("user")]
		[Function("user/get-followers-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetFollowersById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid userId

		)
		{
			return await _sender.Send(new GetFollowersByUserIdRequestDto(userId));
		}


		[Authorize("user")]
		[Function("user/get-active-profile-image-by-user-id/{userId}")]
		public async Task<byte[]> GetActiveProfileImageByUserId(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid userId
		)
		{
			return await _sender.Send(new GetActiveProfileImageByIdRequestDto(userId));
		}

		[Authorize("user")]
		[Function("user/add-profile-image")]
		public async Task<AppResponseDto> AddProfileImageByUserId(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
		)
		{
			return await _sender.Send(new AddProfileImageRequestDto(await MultipartFormDataParser.ParseAsync(req.Body)));
		}



	}
}
