using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserConversationModelBuilder : IEntityTypeConfiguration<UserConversation>
	{
		public void Configure(EntityTypeBuilder<UserConversation> builder)
		{
			builder.HasKey(x => new { x.UserId, x.ConversationId });
		}
	}
}
