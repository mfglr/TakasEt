using Application.Dtos;
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
        public async Task<AddCategoryResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            string json;
            using (var reader = new StreamReader(req.Body))
                json = await reader.ReadToEndAsync();
            var category = JsonConvert.DeserializeObject<AddCategoryRequestDto>(json);
            return await _mediator.Send(category);
        }
    }
}
