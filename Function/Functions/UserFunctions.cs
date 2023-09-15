using Application.Dtos;
using Application.Dtos.SignUp;
using Function.Attributes;
using Function.Extentions;
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
		public async Task<AppResponseDto<SignUpResponseDto>> SingUp([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<SignUpRequestDto>());
		}

		[Function("login")]
		public async Task<AppResponseDto<TokenDto>> Login([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<LoginDto>());
		}

		[Authorize("user","client")]
		[Function("get-user-by-username/{username}")]
		public async Task<AppResponseDto<UserResponseDto>> GetUser(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			string username
		)
		{
			return await _sender.Send(new GetUserByUserNameRequestDto(username));
		}

		[Authorize("admin","user")]
		[Function("remove-user/{id}")]
		public async Task<AppResponseDto<NoContentResponseDto>> RemoveUser(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req,
			Guid id
		)
		{
			return await _sender.Send(new RemoveUserRequestDto(id));
		}
	}
}
