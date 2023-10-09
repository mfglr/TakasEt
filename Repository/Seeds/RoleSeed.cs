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
				new { Id = Guid.Parse("9dbcc1a1-2350-4f95-a7a1-3802818843fe"), Name = "client", CreatedDate = DateTime.UtcNow },
				new { Id = Guid.Parse("4dec4e47-9808-4fea-b6e9-a54b2da571cf"), Name = "user", CreatedDate = DateTime.UtcNow },
				new { Id = Guid.Parse("a1adfeff-b017-4825-a595-1a691fef079a"), Name = "admin", CreatedDate = DateTime.UtcNow }
			);
		}
	}
}
