using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class ArticleModelBuilder : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder
				.HasMany(x => x.Comments)
				.WithOne(x => x.Article)
				.HasForeignKey(x => x.ArticleId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
