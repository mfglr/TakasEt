using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class FollowingSeed : IEntityTypeConfiguration<Following>
	{
		public void Configure(EntityTypeBuilder<Following> builder)
		{
			builder.HasData(
				new[]
				{
					new
					{
						FollowerId = 1,
						FollowingId = 2,
						CreatedDate = DateTime.Now
					},
					new
					{
						FollowerId = 2,
						FollowingId = 1,
						CreatedDate = DateTime.Now
					}
				}
			);
		}
	}
}
