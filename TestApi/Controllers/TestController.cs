using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using System.Data;

namespace TestApi.Controllers
{
	public class TestController : ControllerBase
	{

		private readonly IRepository<Test> _tests;
		private readonly AppDbContext _context;

		public TestController(IRepository<Test> tests, AppDbContext context)
		{
			_tests = tests;
			_context = context;
		}

		[HttpPut("api/test/increase-counter")]
		public async Task IncreaseCounter()
		{
			try
			{
				var t = _context.Database.BeginTransaction(IsolationLevel.RepeatableRead);
				var test = await _tests.DbSet.FindAsync(1);
				test.IncreaseCounter();
				await _context.SaveChangesAsync();
				await t.CommitAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}
