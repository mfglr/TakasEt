﻿using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class UserModelBuilder : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.Name).HasColumnType("varchar(50)");
			builder.Property(x => x.Name).HasColumnType("varchar(50)");
			builder.Property(x => x.UserName).HasColumnType("varchar(50)");
			builder.Property(x => x.NormalizedFullName).HasColumnType("varchar(100)");
			builder.Property(x => x.UserName).HasColumnType("varchar(50)");
			builder.Property(x => x.NormalizedUserName).HasColumnType("varchar(50)");
			builder.Property(x => x.Email).HasColumnType("varchar(100)");
			builder.Property(x => x.NormalizedEmail).HasColumnType("varchar(100)");

			builder.HasIndex(x => x.NormalizedEmail).IsUnique().HasDatabaseName("emailIndexer");
			builder.HasIndex(x => x.NormalizedUserName).IsUnique().HasDatabaseName("userNameIndexer");
			builder.HasIndex(x => x.NormalizedFullName).HasDatabaseName("fullNameIndexer");

			builder
				.HasMany(x => x.Posts)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

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
				.HasMany(x => x.UserImages)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

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
				.HasMany(x => x.Followings)
				.WithOne(x => x.Follower)
				.HasForeignKey(x => x.FollowerId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Followers)
				.WithOne(x => x.Followed)
				.HasForeignKey (x => x.FollowingId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.LikedComments)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Searchings)
				.WithOne(x => x.User)
				.HasForeignKey(x =>x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UserPostExplorings)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UserConversations)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
