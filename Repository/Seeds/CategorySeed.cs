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
					Id = 1,
					CreatedDate = DateTime.Now,
					Name = "Kitap",
					NormalizedName = "KITAP",
					IsRemoved = false
				},
				new
				{
					Id = 2,
					CreatedDate = DateTime.Now,
					Name = "Araba",
					NormalizedName = "ARABA",
					IsRemoved = false
				},
				new
				{
					Id = 3,
					CreatedDate = DateTime.Now,
					Name = "Elektronik",
					NormalizedName = "ELEKTRONIK",
					IsRemoved = false
				},
				new
				{
					Id = 4,
					CreatedDate = DateTime.Now,
					Name = "Giyim",
					NormalizedName = "GIYIM",
					IsRemoved = false
				},
				new
				{
					Id = 5,
					CreatedDate = DateTime.Now,
					Name = "Ev Eşyaları",
					NormalizedName = "EV ESYALARI",
					IsRemoved = false
				},
				new
				{
					Id = 6,
					CreatedDate = DateTime.Now,
					Name = "Telefon",
					NormalizedName = "TELEFON",
					IsRemoved = false
				},
				new
				{
					Id = 7,
					CreatedDate = DateTime.Now,
					Name = "Bilgisayar",
					NormalizedName = "BILGISAYAR",
					IsRemoved = false
				},
				new
				{
					Id = 8,
					CreatedDate = DateTime.Now,
					Name = "Motor",
					NormalizedName = "MOTOR",
					IsRemoved = false
				}
			);
		}
	}
}
