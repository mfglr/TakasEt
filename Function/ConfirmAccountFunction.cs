using Application.Dtos;
using Application.Dtos.SignUp;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function
{
    public class ConfirmAccountFunction
    {
        private readonly IMediator _mediator;

		public ConfirmAccountFunction(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Function("{userName}/ConfirmAccountFunction/{token}")]
        public async Task<NoContentResponseDto> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            string userName,
            string token)
        {
            return await _mediator.Send(new ConfirmAccountCommandRequestDto(userName,token));
        }
    }
}
