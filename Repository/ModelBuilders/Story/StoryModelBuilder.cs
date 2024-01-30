using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class StoryModelBuilder : IEntityTypeConfiguration<Story>
	{
		public void Configure(EntityTypeBuilder<Story> builder)
		{
			builder
				.HasMany(x => x.StoryImages)
				.WithOne(x => x.Story)
				.HasForeignKey(x => x.StoryId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
