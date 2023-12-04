using Application.Dtos;
using Application.Entities;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using MediatR;
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
		private readonly IRepository<Test> _tests;
		private readonly IUnitOfWork _unitOfWork;


		public TestController(ISender sender, IRepository<Category> categories, IUnitOfWork unitOfWork, IRepository<Test> tests)
		{
			_sender = sender;
			_categories = categories;
			_unitOfWork = unitOfWork;
			_tests = tests;
		}

		[HttpPut("test/increase-counter")]
		public async Task<AppResponseDto> IncreaseCounter()
		{
			return await _sender.Send(new IncreateCounter());	
		}

		[HttpPut("test/change-name")]
		public async Task<AppResponseDto> ChangeName()
		{
			return await _sender.Send(new ChangeName());
		}

		[HttpGet("test/read")]
		public async Task<Test> Read()
		{
			return await _tests.DbSet.AsNoTracking().FirstAsync(x => x.Id == 1);
		}
	}
}
