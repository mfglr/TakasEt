using ChatMicroservice.Domain.MessageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMicroservice.Infrastructure.Configurations
{
	public class MessageModelBuilder : IEntityTypeConfiguration<Message>
	{
		public void Configure(EntityTypeBuilder<Message> builder)
		{
			builder.OwnsOne(
				message => message.MessageState,
				builder =>
				{
					builder.Property(messageState => messageState.Status).HasColumnName("Status");
				}
			);
		}
	}
}
