using ConversationService.Domain.ConversationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
{
    public class ConversationModelBuilder : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasIndex(x => x.CreatedDate).HasDatabaseName("CreatedDateIndexer");
        }
    }
}
