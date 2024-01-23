﻿using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserImageModelBuilder : IEntityTypeConfiguration<UserImage>
	{
		public void Configure(EntityTypeBuilder<UserImage> builder)
		{
			builder.OwnsOne(
				userImage => userImage.ContainerName,
				x => {
					x.Property(containerName => containerName.Value).HasColumnName("ContainerName");
				}
			);

			builder.OwnsOne(
				userImage => userImage.Dimension,
				x => {
					x.Property(dimention => dimention.Height).HasColumnName("Height");
					x.Property(dimention => dimention.Width).HasColumnName("Width");
				}
			);
		}
	}
}
