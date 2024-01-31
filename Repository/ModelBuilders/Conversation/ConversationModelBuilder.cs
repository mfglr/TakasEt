using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class ConversationModelBuilder : IEntityTypeConfiguration<Conversation>
	{
		public void Configure(EntityTypeBuilder<Conversation> builder)
		{

			builder
				.HasMany(x => x.Messages)
				.WithOne(x => x.Conversation)
				.HasForeignKey(x => x.ConversationId )
				.OnDelete(DeleteBehavior.NoAction);
			
			builder
				.HasMany(x => x.UsersWhoRemovedTheEntity)
				.WithOne(x => x.Conversation)
				.HasForeignKey(x => x.ConversationId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
