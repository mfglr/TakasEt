using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class UserImageSeed : IEntityTypeConfiguration<UserImage>
	{
		public void Configure(EntityTypeBuilder<UserImage> builder)
		{
			builder.HasData(
				new[]
				{
					new
					{
						Id = 1,
						IsActive = true,
						UserId = 1,
						BlobName = "1.jpg",
						Extention = "jpg",
						ContainerName = "user-image",
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 2,
						IsActive = true,
						UserId = 2,
						BlobName = "2.jpg",
						Extention = "jpg",
						ContainerName = "user-image",
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					}
				}
			);
		}
	}
}
