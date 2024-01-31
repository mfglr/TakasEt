using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

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
				.HasMany(x => x.PostsLiked)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Followings)
				.WithOne(x => x.FollowerUser)
				.HasForeignKey(x => x.FollowerId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Followers)
				.WithOne(x => x.FollowingUser)
				.HasForeignKey (x => x.FollowingId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.CommentsLiked)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Searchings)
				.WithOne(x => x.User)
				.HasForeignKey(x =>x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.PostsExplored)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Stories)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.StoryImagesLiked)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);
			
			builder
				.HasMany(x => x.StoryImagesViewed)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(x => x.UserAppState)
				.WithOne(x => x.User)
				.HasForeignKey<UserAppState>(x => x.Id)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(x => x.MessageHubState)
				.WithOne(x => x.User)
				.HasForeignKey<MessageHubState>(x => x.Id)
				.OnDelete(DeleteBehavior.NoAction);

			

			builder
				.HasMany(x => x.MessagesRemoved)
				.WithOne(x => x.Remover)
				.HasForeignKey(x => x.RemoverId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Groups)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersWhoViewed)
				.WithOne(x => x.Viewed)
				.HasForeignKey (x => x.ViewedId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersViewed)
				.WithOne(x => x.Viewer)
				.HasForeignKey(x => x.ViewerId)
				.OnDelete(DeleteBehavior.NoAction);

			//Conversation
			builder
				.HasMany(x => x.ConversationsSent)
				.WithOne(x => x.Receiver)
				.HasForeignKey(x => x.ReceiverId)
				.OnDelete(DeleteBehavior.NoAction);
			builder
				.HasMany(x => x.ConversationsReceived)
				.WithOne(x => x.Sender)
				.HasForeignKey(x => x.SenderId)
				.OnDelete (DeleteBehavior.NoAction);
			builder
				.HasMany(x => x.ConversationsRemoved)
				.WithOne(x => x.Remover)
				.HasForeignKey(x => x.RemoverId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
