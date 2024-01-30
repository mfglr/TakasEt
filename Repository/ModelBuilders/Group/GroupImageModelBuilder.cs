using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class GroupImageModelBuilder : IEntityTypeConfiguration<GroupImage>
	{
		public void Configure(EntityTypeBuilder<GroupImage> builder)
		{
			builder.OwnsOne(
				x => x.ContainerName,
				containerName =>
				{
					containerName.Property(x => x.Value).HasColumnName("ContainerName");
				}
			);

			builder.OwnsOne(
				postImage => postImage.Dimension,
				x => {
					x.Property(dimention => dimention.Height).HasColumnName("Height");
					x.Property(dimention => dimention.Width).HasColumnName("Width");
					x.Property(dimension => dimension.AspectRatio).HasColumnName("AspectRatio");
				}
			);

		}
	}
}
