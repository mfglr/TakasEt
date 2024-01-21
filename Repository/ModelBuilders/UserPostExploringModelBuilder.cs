using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserPostExploringModelBuilder : IEntityTypeConfiguration<UserPostExploring>
	{
		public void Configure(EntityTypeBuilder<UserPostExploring> builder)
		{
			builder.HasKey(x => new { x.UserId, x.PostId });
		}
	}
}
