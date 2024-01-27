using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class UserRoleModelBuilder : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.HasKey(x => new { x.UserId, x.RoleId });
		}
	}
}
