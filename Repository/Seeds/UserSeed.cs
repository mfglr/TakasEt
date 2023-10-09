using Application.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class UserSeed : IEntityTypeConfiguration<User>
	{

		public void Configure(EntityTypeBuilder<User> builder)
		{

			builder.HasData(
				new
				{
					NormalizedUserName = "THENQLV",
					NormalizedEmail = "THENQLV@OUTLOOK.COM",
					PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
					EmailConfirmed = false,
					PhoneNumberConfirmed = false,
					TwoFactorEnabled = false,
					AccessFailedCount = 0,
					LockoutEnabled = true,
					SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
					ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
					CreatedDate = DateTime.UtcNow,
					Id = Guid.Parse("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
					Email = "thenqlv@outlook.com",
					UserName = "thenqlv",
					Gender = true,
					Name = "Furkan",
					LastName = "Guler",
					DateOfBirth = new DateTime(1998,1,17)
				}
			) ;
		}
	}
}
