using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		[Authorize(Roles = "user")]
		[HttpPost("category/add-category")]
		public async Task<AppResponseDto> AddCategory(AddCategoryDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("category/filter-categories")]
		public async Task<AppResponseDto> FilterCategories()
		{
			return await _sender.Send(new FilterCategoriesDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("category/get-categories")]
		public async Task<AppResponseDto> GetCategories()
		{
			return await _sender.Send(new GetCategoriesDto(Request.Query));
		}
	}
}
