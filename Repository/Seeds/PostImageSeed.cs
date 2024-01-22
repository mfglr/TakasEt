using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class PostImageSeed : IEntityTypeConfiguration<PostImage>
	{
		public void Configure(EntityTypeBuilder<PostImage> builder)
		{
			builder.HasData(
				new[]
				{
					new
					{
						Id = 1,
						BlobName = "1_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 1,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 2,
						BlobName = "1_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 1,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 3,
						BlobName = "1_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 1,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 4,
						BlobName = "2_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 2,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 5,
						BlobName = "2_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 2,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 6,
						BlobName = "2_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 2,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 7,
						BlobName = "3_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 3,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 8,
						BlobName = "3_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 3,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 9,
						BlobName = "3_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 3,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 10,
						BlobName = "4_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 4,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 11,
						BlobName = "4_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 4,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 12,
						BlobName = "4_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 4,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 13,
						BlobName = "5_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 5,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 14,
						BlobName = "5_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 5,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 15,
						BlobName = "5_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 5,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 16,
						BlobName = "6_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 6,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 17,
						BlobName = "6_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 6,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 18,
						BlobName = "6_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 6,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 19,
						BlobName = "7_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 7,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 20,
						BlobName = "7_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 7,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 21,
						BlobName = "7_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 7,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 22,
						BlobName = "8_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 8,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 23,
						BlobName = "8_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 8,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 24,
						BlobName = "8_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 8,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 25,
						BlobName = "9_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 9,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 26,
						BlobName = "9_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 9,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 27,
						BlobName = "9_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 9,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 28,
						BlobName = "10_0.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 10,
						Index = 0,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 29,
						BlobName = "10_1.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 10,
						Index = 1,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					},
					new
					{
						Id = 30,
						BlobName = "10_2.jpg",
						ContainerName = "post-image",
						Extention = "jpg",
						PostId = 10,
						Index = 2,
						CreatedDate = DateTime.Now,
						IsRemoved = false,
					}

				}
			);
		}
	}
}
