using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class ProfilePictureModelBuilder : IEntityTypeConfiguration<ProfilePicture>
	{
		public void Configure(EntityTypeBuilder<ProfilePicture> builder)
		{
			builder.OwnsOne(p => p.Image, p =>
			{
				p.Property(x => x.BlobName).HasColumnName("BlobNameOfFile");
				p.Property(x => x.ContainerName).HasColumnName("ContainerNameOfFile");
			});
		}
	}
}
