using ChatMicroservice.Domain.GroupAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMicroservice.Infrastructure.Configurations
{
	public class GroupImageModelBuilder : IEntityTypeConfiguration<GroupImage>
	{
		public void Configure(EntityTypeBuilder<GroupImage> builder)
		{
			builder
				.OwnsOne(
					x => x.ContainerName,
					x => {
						x.Property(x => x.Value).HasColumnName("ContainerName");
					}
				);

			builder.OwnsOne(
				x => x.Dimension,
				x => {
					x.Property(dimension => dimension.Height).HasColumnName("Height");
					x.Property(dimension => dimension.Width).HasColumnName("Width");
					x.Property(dimension => dimension.AspectRatio).HasColumnName("AspectRatio");
				}
			);
		}
	}
}
