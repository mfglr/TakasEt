using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class PostUserLikingModelBuilder : IEntityTypeConfiguration<PostUserLiking>
	{
		public void Configure(EntityTypeBuilder<PostUserLiking> builder)
		{
			builder.HasKey(x => new { x.PostId, x.UserId });
		}
	}
}
