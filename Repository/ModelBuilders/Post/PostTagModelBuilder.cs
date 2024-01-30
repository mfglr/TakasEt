using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class PostTagModelBuilder : IEntityTypeConfiguration<PostTag>
	{
		public void Configure(EntityTypeBuilder<PostTag> builder)
		{
			builder.HasKey(x => new { x.PostId, x.TagId });
		}
	}
}
