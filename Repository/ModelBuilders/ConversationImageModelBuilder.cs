using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class ConversationImageModelBuilder : IEntityTypeConfiguration<ConversationImage>
	{
		public void Configure(EntityTypeBuilder<ConversationImage> builder)
		{
			builder.OwnsOne(
				conversationImage => conversationImage.ContainerName,
				x => {
					x.Property(containerName => containerName.Value).HasColumnName("ContainerName");
				}
			);

			builder.OwnsOne(
				conversationImage => conversationImage.Dimension,
				x => {
					x.Property(dimension => dimension.Height).HasColumnName("Height");
					x.Property(dimension => dimension.Width).HasColumnName("Width");
				}
			);
		}
	}
}
