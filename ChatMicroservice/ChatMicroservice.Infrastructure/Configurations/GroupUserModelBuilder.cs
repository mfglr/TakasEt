using ChatMicroservice.Domain.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMicroservice.Infrastructure.Configurations
{
	public class GroupUserModelBuilder : IEntityTypeConfiguration<GroupUser>
	{
		public void Configure(EntityTypeBuilder<GroupUser> builder)
		{
			builder.OwnsOne(
				x => x.Role,
				x => {
					x.Property(x => x.Role).HasColumnName("Role");
				}
			);
		}
	}
}
