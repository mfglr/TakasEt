using Application.Dtos;
using Application.Dtos.ConfirmEmail;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

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
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string userName,
            string token)
        {
			var response = req.CreateResponse(HttpStatusCode.OK);
			response.Headers. = new MediaTypeHeaderValue("text/html");
			var html = await _mediator.Send(new ConfirmEmailCommandRequestDto(userName, token));




		}
    }
}
