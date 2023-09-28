using Application.Dtos;
using Function.Attributes;
using Function.Extentions;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class CategoryFunctions
    {
        private readonly ISender _sender;

        public CategoryFunctions(ISender sender)
        {
			_sender = sender;
        }

        [Authorize("user")]
        [Function("category/add-category")]
        public async Task<AppResponseDto> AddCategory([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _sender.Send(await req.ReadFromBodyAsync<AddCategoryRequestDto>());
        }

        [Authorize("user")]
        [Function("category/filter-categories/{key}")]
        public async Task<AppResponseDto> FilterCategories([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,string key)
        {
            return await _sender.Send(new FilterCategoriesRequestDto(key));
        }
    }
}
