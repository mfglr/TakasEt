using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class TagModelBuilder : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder
				.HasMany(x => x.Posts)
				.WithOne(x => x.Tag)
				.HasForeignKey(x => x.TagId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
