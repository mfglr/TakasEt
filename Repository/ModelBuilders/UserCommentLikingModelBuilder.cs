using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserCommentLikingModelBuilder : IEntityTypeConfiguration<UserCommentLiking>
	{
		public void Configure(EntityTypeBuilder<UserCommentLiking> builder)
		{
			builder.HasKey(x => new { x.UserId,x.CommentId });
		}
	}
}
