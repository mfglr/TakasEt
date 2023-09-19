using Application.Dtos;
using Function.Extentions;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.Functions
{
    public class CategoryFunctions
    {
        private readonly IMediator _mediator;

        public CategoryFunctions(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Function("add-category")]
        public async Task<AppResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _mediator.Send(await req.ReadFromBodyAsync<AddCategoryRequestDto>());
        }
    }
}
