using ConversationService.Domain.UserConnectionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConversationService.Infrastructure.ModelBuilders
{
    public class UserConnectionModelBuilder : IEntityTypeConfiguration<UserConnection>
    {

        public void Configure(EntityTypeBuilder<UserConnection> builder)
        {
            builder
                .HasMany(x => x.Messages)
                .WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
