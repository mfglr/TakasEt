using Application.Dtos;
using Application.Dtos.ConfirmEmail;
using Application.Dtos.SignUp;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.ConfirmAccount
{
    public class ConfirmAccountFunction
    {
        private readonly IMediator _mediator;

        public ConfirmAccountFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Function("ConfirmAccountFunction/{userName}/{token}")]
        public async Task<NoContentResponseDto> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string userName,
            string token)
        {
            return await _mediator.Send(new ConfirmEmailCommandRequestDto(userName, token));
        }
    }
}
