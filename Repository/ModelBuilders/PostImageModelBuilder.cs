using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class PostImageModelBuilder : IEntityTypeConfiguration<PostImage>
	{
		public void Configure(EntityTypeBuilder<PostImage> builder)
		{
			builder.OwnsOne(
				postImage => postImage.ContainerName,
				x => {
					x.Property(containerName => containerName.Value).HasColumnName("ContainerName");
				}
			);

			builder.OwnsOne(
				postImage => postImage.Dimension,
				x => {
					x.Property(dimention => dimention.Height).HasColumnName("Height");
					x.Property(dimention => dimention.Width).HasColumnName("Width");
				}
			);
		}
	}
}
