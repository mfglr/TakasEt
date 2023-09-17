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
				new { Id = Guid.NewGuid(), Name = "client", CreatedDate = DateTime.UtcNow },
				new { Id = Guid.NewGuid(), Name = "user", CreatedDate = DateTime.UtcNow },
				new { Id = Guid.NewGuid(), Name = "admin", CreatedDate = DateTime.UtcNow }
			);
		}
	}
}
