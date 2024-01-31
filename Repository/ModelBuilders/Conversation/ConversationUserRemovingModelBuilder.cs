using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class ConversationUserRemovingModelBuilder : IEntityTypeConfiguration<ConversationUserRemoving>
	{
		public void Configure(EntityTypeBuilder<ConversationUserRemoving> builder)
		{
			builder.HasKey( x => new { x.ConversationId, x.RemoverId } );
		}
	}
}
