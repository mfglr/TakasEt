using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class SwappingCommentContentModelBuilder : IEntityTypeConfiguration<SwappingCommentContent>
	{
		public void Configure(EntityTypeBuilder<SwappingCommentContent> builder)
		{
			builder.Property(x => x.Content).HasColumnType("varchar(100)");
			builder
				.HasMany(x => x.SwappingComments)
				.WithOne(x => x.SwappingCommentContent)
				.HasForeignKey(x => x.SwappingCommentContentId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
