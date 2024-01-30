using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class MessageUserRemovingModelBuilder : IEntityTypeConfiguration<MessageUserRemoving>
	{
		public void Configure(EntityTypeBuilder<MessageUserRemoving> builder)
		{
			builder.HasKey(x => new { x.MessageId, x.RemoverId });
		}
	}
}
