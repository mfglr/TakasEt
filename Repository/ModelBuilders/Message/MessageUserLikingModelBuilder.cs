using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class MessageUserLikingModelBuilder : IEntityTypeConfiguration<MessageUserLiking>
	{
		public void Configure(EntityTypeBuilder<MessageUserLiking> builder)
		{
			builder.HasKey(x => new {x.MessageId, x.UserId});
		}
	}
}
