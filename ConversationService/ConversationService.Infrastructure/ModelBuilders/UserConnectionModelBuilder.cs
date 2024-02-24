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
                .HasMany(x => x.IncomingConversations)
                .WithOne()
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.OutgoingConversations)
                .WithOne()
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.UsersWhoCanSendMessageToTheUser)
                .WithOne()
                .HasForeignKey(x => x.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheUserCanSendMessage)
                .WithOne()
                .HasForeignKey(x => x.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
