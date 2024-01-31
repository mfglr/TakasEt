using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class MessageModelBuilder : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.Property(x => x.Content).HasColumnType("varchar(512)");
			builder.Property(x => x.NormalizeContent).HasColumnType("varchar(512)");

			builder.OwnsOne(
				message => message.MessageState,
				x =>
				{
					x.Property(messageState => messageState.Status).HasColumnName("Status");
				}
			);

			builder
				.HasMany(x => x.UsersWhoLiked)
				.WithOne(x => x.Message)
				.HasForeignKey(x => x.MessageId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersWhoViewed)
				.WithOne(x => x.Message)
				.HasForeignKey(x => x.MessageId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.UsersWhoRemovedTheEntity)
				.WithOne(x => x.Message)
				.HasForeignKey(x => x.MessageId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.MessageImages)
				.WithOne(x => x.Message)
				.HasForeignKey(x => x.MessageId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
