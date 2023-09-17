using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class UserModelBuilder : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{

			builder
				.HasMany(x => x.Comments)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId) 
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(x => x.UserRefreshToken)
				.WithOne(x => x.User)
				.HasForeignKey<UserRefreshToken>(x => x.UserId);

			builder
				.HasMany(x => x.ProfilePictures)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId);

			builder
				.HasMany(x => x.Roles)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.LikedPosts)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.ViewedPosts)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
