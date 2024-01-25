using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserStoryImageViewingModelBuilder : IEntityTypeConfiguration<UserStoryImageViewing>
	{
		public void Configure(EntityTypeBuilder<UserStoryImageViewing> builder)
		{
			builder.HasKey(x => new {x.UserId,x.StoryImageId});
		}
	}
}
