using System.Net;
using Application.Dtos.SignUp;
using FluentValidation;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.SignUp
{
    public class SignUpFunction
    {
        private readonly IMediator _mediator;
        private readonly IValidator<SignUpCommandRequestDto> _validator;

		public SignUpFunction(IMediator mediator, IValidator<SignUpCommandRequestDto> validator)
		{
			_mediator = mediator;
			_validator = validator;
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
