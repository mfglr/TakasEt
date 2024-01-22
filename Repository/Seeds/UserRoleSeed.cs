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
				new[]
				{
					new { UserId = 1, RoleId = 2, CreatedDate = DateTime.Now },
					new { UserId = 2, RoleId = 2, CreatedDate = DateTime.Now }
				}
			);
			
		}
	}
}
