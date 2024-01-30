using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class ConversationModelBuilder : IEntityTypeConfiguration<Conversation>
	{
		public void Configure(EntityTypeBuilder<Conversation> builder)
		{

			builder.HasKey(x => new { x.SenderId, x.ReceiverId });

			builder
				.HasMany(x => x.Messages)
				.WithOne(x => x.Conversation)
				.HasForeignKey(x => new { x.SenderId,x.ReceiverId } )
				.OnDelete(DeleteBehavior.NoAction);
			
			builder
				.HasMany(x => x.UsersWhoRemoved)
				.WithOne(x => x.Conversation)
				.HasForeignKey(x => new { x.SenderId,x.ReceiverId } )
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
