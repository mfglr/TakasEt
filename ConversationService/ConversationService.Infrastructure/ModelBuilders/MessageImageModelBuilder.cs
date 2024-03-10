using ConversationService.Domain.MessageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
{
    public class MessageImageModelBuilder : IEntityTypeConfiguration<MessageImage>
    {
        public void Configure(EntityTypeBuilder<MessageImage> builder)
        {
            builder.OwnsOne(x => x.Dimension);
            builder.OwnsOne(x => x.ContainerName);
        }
    }
}
