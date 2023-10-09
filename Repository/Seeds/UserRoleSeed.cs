using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class UserRoleSeed : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasData(
				new
				{
					Id = Guid.Parse("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
					UserId = Guid.Parse("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
					RoleId = Guid.Parse("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
					CreatedDate = DateTime.UtcNow
				}
			);
		}

	}
}
