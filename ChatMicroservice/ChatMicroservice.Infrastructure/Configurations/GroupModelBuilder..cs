using ChatMicroservice.Domain.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMicroservice.Infrastructure.Configurations
{
	public class GroupModelBuilder : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.OwnsOne(
				x => x.GroupType,
				x => {
					x.Property(x => x.Type).HasColumnName("Type");
				}
			);
		}
	}
}
