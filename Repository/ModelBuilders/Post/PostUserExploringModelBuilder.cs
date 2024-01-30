using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class PostUserExploringModelBuilder : IEntityTypeConfiguration<PostUserExploring>
	{
		public void Configure(EntityTypeBuilder<PostUserExploring> builder)
		{
			builder.HasKey(x => new { x.PostId, x.UserId });
		}
	}
}
