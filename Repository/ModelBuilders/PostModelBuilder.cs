using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	internal class PostModelBuilder : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.Property(x => x.Title).HasColumnType("varchar(256)");
			builder.Property(x => x.NormalizedTitle).HasColumnType("varchar(256)");
			builder.HasIndex(x => x.NormalizedTitle).HasDatabaseName("titleIndexer");

			builder
				.HasMany(x => x.Comments)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersWhoLiked)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.PostImages)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.RequesterPosts)
				.WithOne(x => x.Requested)
				.HasForeignKey(x => x.RequestedId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.RequestedPosts)
				.WithOne(x => x.Requester)
				.HasForeignKey(x => x.RequesterId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Tags)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.RequesterSwappings)
				.WithOne(x => x.Requested)
				.HasForeignKey(x => x.RequestedId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.RequestedSwappings)
				.WithOne(x => x.Requester)
				.HasForeignKey(x => x.RequesterId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersWhoExplored)
				.WithOne(x => x.Post)
				.HasForeignKey(x => x.PostId);
		}
	}
}
