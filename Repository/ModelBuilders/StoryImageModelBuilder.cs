using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class StoryImageModelBuilder : IEntityTypeConfiguration<StoryImage>
	{
		public void Configure(EntityTypeBuilder<StoryImage> builder)
		{

			builder.OwnsOne(
				storyImage => storyImage.ContainerName,
				x =>
				{
					x.Property(containerName => containerName.Value).HasColumnName("ContainerName");
				}
			);

			builder.OwnsOne(
				userImage => userImage.Dimension,
				x => {
					x.Property(dimention => dimention.Height).HasColumnName("Height");
					x.Property(dimention => dimention.Width).HasColumnName("Width");
					x.Property(dimension => dimension.AspectRatio).HasColumnName("AspectRatio");
				}
			);

			builder
				.HasMany(x => x.Likes)
				.WithOne(x => x.StoryImage)
				.HasForeignKey(x => x.StoryImageId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Viewings)
				.WithOne(x => x.StoryImage)
				.HasForeignKey(x => x.StoryImageId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
