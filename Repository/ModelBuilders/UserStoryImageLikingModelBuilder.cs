using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserStoryImageLikingModelBuilder : IEntityTypeConfiguration<UserStoryImageLiking>
	{
		public void Configure(EntityTypeBuilder<UserStoryImageLiking> builder)
		{
			builder.HasKey(x => new { x.UserId, x.StoryImageId });
		}
	}
}
