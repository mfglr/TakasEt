using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class ConversationUserModelBuilder : IEntityTypeConfiguration<ConversationUser>
	{
		public void Configure(EntityTypeBuilder<ConversationUser> builder)
		{
			builder.HasKey(x => new { x.ConversationId, x.UserId });
		}
	}
}
