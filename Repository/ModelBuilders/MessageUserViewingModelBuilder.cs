using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class MessageUserViewingModelBuilder : IEntityTypeConfiguration<MessageUserViewing>
	{
		public void Configure(EntityTypeBuilder<MessageUserViewing> builder)
		{
			builder.HasKey(x => new { x.MessageId, x.UserId });
		}
	}
}
