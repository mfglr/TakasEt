using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class MessageImageModelBuilder : IEntityTypeConfiguration<MessageImage>
	{
		public void Configure(EntityTypeBuilder<MessageImage> builder)
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
