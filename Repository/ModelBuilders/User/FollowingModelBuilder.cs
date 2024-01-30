using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class FollowingModelBuilder : IEntityTypeConfiguration<Following>
	{
		public void Configure(EntityTypeBuilder<Following> builder)
		{
			builder.HasKey(x => new { x.FollowerId, x.FollowingId });
		}
	}
}
