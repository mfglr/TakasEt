using Application.Dtos.ConfirmEmail;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.ConfirmEmail
{
	public class ConfirmEmailFunction
    {
        private readonly IMediator _mediator;

		public ConfirmEmailFunction(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Function("ConfirmEmail/{userName}/{token}")]
        public async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string userName,
            string token)
        {
			return await _mediator.Send(new ConfirmEmailCommandRequestDto(userName, token));
		}
    }
}
