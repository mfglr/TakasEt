using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class PostUserViewingModelBuilder : IEntityTypeConfiguration<PostUserViewing>
	{
		public void Configure(EntityTypeBuilder<PostUserViewing> builder)
		{
			builder.HasKey(x => new { x.PostId, x.UserId });
		}
	}
}
