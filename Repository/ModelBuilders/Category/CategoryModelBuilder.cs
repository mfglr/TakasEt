using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	internal class CategoryModelBuilder : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).HasColumnType("varchar(256)");
			builder.Property(x => x.NormalizedName).HasColumnType("varchar(256)");

			builder
				.HasMany(x => x.Posts)
				.WithOne(x => x.Category)
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

		}
	}
}
