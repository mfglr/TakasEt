using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ISender _sender;

		public CategoryController(ISender sender)
		{
			_sender = sender;
		}

		
		[HttpPost("category/add-category")]
		public async Task<AppResponseDto> AddCategory(AddCategoryDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPut("category/update-category")]
		public async Task<AppResponseDto> UpdateCategory(UpdateCategoryDto request)
		{
			return await _sender.Send(request);
		}

		[HttpDelete("category/delte-category/{id}")]
		public async Task<AppResponseDto> DeleteCategory(int id)
		{
			return await _sender.Send(new DeleteCategoryDto(id));
		}

		[HttpGet("category/filter-categories")]
		public async Task<AppResponseDto> FilterCategories()
		{
			return await _sender.Send(new FilterCategoriesDto(Request.Query));
		}

		[HttpGet("category/get-categories")]
		public async Task<AppResponseDto> GetCategories()
		{
			return await _sender.Send(new GetCategoriesDto(Request.Query));
		}
	}
}
