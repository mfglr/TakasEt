using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class CommentUserLikingModelBuilder : IEntityTypeConfiguration<CommentUserLiking>
	{
		public void Configure(EntityTypeBuilder<CommentUserLiking> builder)
		{
			builder.HasKey(x => new { x.CommentId, x.UserId });
		}
	}
}
