using ConversationService.Domain.ConversationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
{
    public class ConversationModelBuilders : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(x => new {x.UserId1,x.UserId2});
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
