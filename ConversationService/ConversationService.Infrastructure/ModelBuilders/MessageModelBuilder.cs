using ConversationService.Domain.ConversationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
{
    public class MessageModelBuilder : IEntityTypeConfiguration<Message>
    {

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasIndex(x => x.CreatedDate).HasDatabaseName("CreatedDateIndexer");

            builder.OwnsOne(message => message.MessageState);
        }
    }
}
