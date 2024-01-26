using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class StoryImageUserLikingModelBuilder : IEntityTypeConfiguration<StoryImageUserLiking>
	{
		public void Configure(EntityTypeBuilder<StoryImageUserLiking> builder)
		{
			builder.HasKey(x => new { x.StoryImageId, x.UserId });
		}
	}
}
