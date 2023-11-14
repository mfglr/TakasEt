using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class RoleSeed : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasData(
				new { Id = 1, Name = "client", CreatedDate = DateTime.Now },
				new { Id = 2, Name = "user", CreatedDate = DateTime.Now },
				new { Id = 3, Name = "admin", CreatedDate = DateTime.Now }
			);
		}
	}
}
