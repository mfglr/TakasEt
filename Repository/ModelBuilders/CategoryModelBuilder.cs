using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class CategoryModelBuilder : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder
				.HasMany(x => x.Articles)
				.WithOne(x => x.Category)
				.HasForeignKey(x => x.CategoryId);
		}
	}
}
