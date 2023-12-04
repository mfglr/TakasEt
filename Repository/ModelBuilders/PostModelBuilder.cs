using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class PostModelBuilder : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{

			builder.Property(x => x.Title).HasColumnType("varchar(256)");
			builder.Property(x => x.NormalizedTitle).HasColumnType("varchar(256)");
			builder.HasIndex(x => x.NormalizedTitle).HasDatabaseName("titleIndexer");
			builder.HasIndex(x => x.CreatedDate).IsDescending(true).HasDatabaseName("createdDateIndexer");

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
				.HasMany(x => x.Requesters)
				.WithOne(x => x.Requested)
				.HasForeignKey(x => x.RequestedId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Requesteds)
				.WithOne(x => x.Requester)
				.HasForeignKey(x => x.RequesterId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
