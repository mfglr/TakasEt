using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class StoryImageUserViewingModelBuilder : IEntityTypeConfiguration<StoryImageUserViewing>
	{
		public void Configure(EntityTypeBuilder<StoryImageUserViewing> builder)
		{
			builder.HasKey(x => new {x.StoryImageId, x.UserId});
		}
	}
}
