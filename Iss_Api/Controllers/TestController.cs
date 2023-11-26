using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class TestController : ControllerBase
	{

		private readonly ISender _sender;

		private readonly IRepository<Category> _categories;

		public TestController(ISender sender, IRepository<Category> categories)
		{
			_sender = sender;
			_categories = categories;
		}

		[HttpGet("test/deneme")]
		public async Task<Category> Deneme()
		{
			return new Category("deneme");
		}
		[HttpGet("test/deneme1")]
		public async Task<Object> Deneme1()
		{
			Category a; 
			try
			{
				a = await _categories.DbSet.FirstOrDefaultAsync();
			}
			catch(Exception ex)
			{
				return ex.ToString();
			}
			return a;
		}
	}
}
