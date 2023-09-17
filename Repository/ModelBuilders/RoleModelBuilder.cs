using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class RoleModelBuilder : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder
				.HasMany(x => x.Users)
				.WithOne(x => x.Role)
				.HasForeignKey(x => x.RoleId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
