using System.Net;
using Application.Dtos.SignUp;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.SignUp
{
    public class SignUpFunction
    {
        private readonly IMediator _mediator;

        public SignUpFunction(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Function("SignUp")]
        public async Task<SignUpCommandResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            string json;
            using (var reader = new StreamReader(req.Body))
                json = await reader.ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<SignUpCommandRequestDto>(json);
            return await _mediator.Send(data);
        }
    }
}
