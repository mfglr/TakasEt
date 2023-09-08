using Application.Dtos;
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

		[Function("remove-user/{id}")]
		public async Task<NoContentResponseDto> RemoveUser(
			[HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req,
			Guid id
		)
		{
			return await _sender.Send(new RemoveUserRequestDto(id));
		}
	}
}
