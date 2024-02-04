using ChatMicroservice.Domain.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMicroservice.Infrastructure.Configurations
{
	public class GroupUserRequestToJoinModelBuilder : IEntityTypeConfiguration<GroupUserRequestToJoin>
	{
		public void Configure(EntityTypeBuilder<GroupUserRequestToJoin> builder)
		{
			builder.OwnsOne(
				x => x.State,
				x =>
				{
					x.Property(x => x.Status).HasColumnName("Status");
				}
			);
		}
	}
}
