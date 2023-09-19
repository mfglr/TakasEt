using Application.Dtos;
using Function.Extentions;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class AuthenticationFunctions
    {
        private readonly ISender _sender;

		public AuthenticationFunctions(ISender sender)
		{
			_sender = sender;
		}

		[Function("create-token-by-user")]
        public async Task<AppResponseDto> CreateTokenByUser(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
            )
        {
            return await _sender.Send( await req.ReadFromBodyAsync<LoginDto>());
        }

		[Function("create-token-by-client")]
		public async Task<AppResponseDto> CreateTokenByClient(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<ClientLoginDto>());
		}

		[Function("create-token-by-refresh-token")]
		public async Task<AppResponseDto> CreateTokenByRefreshToken(
			[HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req
			)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<RefreshTokenDto>());
		}
	}
}
