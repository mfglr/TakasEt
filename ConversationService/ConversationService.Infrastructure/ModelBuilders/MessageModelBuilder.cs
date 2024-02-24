using ConversationService.Domain.MessageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
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
