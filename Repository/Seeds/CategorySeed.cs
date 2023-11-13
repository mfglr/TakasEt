using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class CategorySeed : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
				new
				{
					Id = Guid.Parse("e17dac4e-3930-457e-858b-96de54391aec"),
					CreatedDate = DateTime.Now,
					Name = "Kitaplar",
					NormalizedName = "KITAPLAR"
				}
			);
		}
	}
}
