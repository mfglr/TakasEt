using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace UnitTest.Test
{
	public class DbContextOptionFactory
	{
		public readonly static DbContextOptions<AppDbContext> DbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
			.UseSqlServer(
				"Data Source=THENQLV;Initial Catalog=TakasEt;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
			)
			.Options;
	}
}
