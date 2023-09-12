using Application.Entities;
using Application.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class RoleSeed : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasData(
				Role.Create(RoleType.User),
				Role.Create(RoleType.Client)
			);
		}
	}
}
