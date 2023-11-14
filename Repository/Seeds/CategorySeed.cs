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
					NormalizedName = "KITAP"
				},
				new
				{
					Id = 2,
					CreatedDate = DateTime.Now,
					Name = "Araba",
					NormalizedName = "ARABA"
				},
				new
				{
					Id = 3,
					CreatedDate = DateTime.Now,
					Name = "Elektronik",
					NormalizedName = "ELEKTRONIK"
				},
				new
				{
					Id = 4,
					CreatedDate = DateTime.Now,
					Name = "Giyim",
					NormalizedName = "GIYIM"
				},
				new
				{
					Id = 5,
					CreatedDate = DateTime.Now,
					Name = "Ev Eşyaları",
					NormalizedName = "EV ESYALARI"
				},
				new
				{
					Id = 6,
					CreatedDate = DateTime.Now,
					Name = "Telefon",
					NormalizedName = "TELEFON"
				},
				new
				{
					Id = 7,
					CreatedDate = DateTime.Now,
					Name = "Bilgisayar",
					NormalizedName = "BILGISAYAR"
				},
				new
				{
					Id = 8,
					CreatedDate = DateTime.Now,
					Name = "Motor",
					NormalizedName = "MOTOR"
				}
			);
		}
	}
}
