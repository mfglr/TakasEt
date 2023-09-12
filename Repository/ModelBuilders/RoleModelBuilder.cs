using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class RoleModelBuilder : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.OwnsOne(x => x.RoleType, x =>
			{
				x.Property(p => p.Name).HasColumnName("roleName");
				x.Property(p => p.Index).HasColumnName("roleIndex");
			});
		}
	}
}
