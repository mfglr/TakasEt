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
		public async Task<AppResponseDto> AddCategory(AddCategory request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("category/filter-categories/{key}")]
		public async Task<AppResponseDto> FilterCategories(string key)
		{
			return await _sender.Send(new FilterCategories(key,Request.Query));
		}
	}
}
