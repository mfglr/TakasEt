using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Seeds
{
	public class UserSeed : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder
				.HasData(
					new[]
					{
						new {
							Id = 1,
							Name = "Furkan",
							LastName = "Guler",
							NormalizedFullName = "FURKAN GULER",
							DateOfBirth = DateTime.Now,
							Gender = true,
							CreatedDate = DateTime.Now,
							UpdatedDate = DateTime.Now,
							UserName = "mfglr",
							NormalizedUserName = "MFGLR",
							Email = "mfglr@outlook.com",
							NormalizedEmail = "MFGLR@OUTLOOK.COM",
							EmailConfirmed = false,
							PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
							SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
							ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
							PhoneNumber = "0000000000",
							PhoneNumberConfirmed = false,
							TwoFactorEnabled = false,
							LockoutEnd = DateTimeOffset.Now,
							LockoutEnabled = true,
							AccessFailedCount = 0,
							NumberOfPost = 5,
							IsRemoved = false
						},
						new {
							Id = 2,
							Name = "test",
							LastName = "test",
							NormalizedFullName = "TEST TEST",
							DateOfBirth = DateTime.Now,
							Gender = true,
							CreatedDate = DateTime.Now,
							UpdatedDate = DateTime.Now,
							UserName = "test",
							NormalizedUserName = "TEST",
							Email = "test@outlook.com",
							NormalizedEmail = "TEST@OUTLOOK.COM",
							EmailConfirmed = false,
							PasswordHash = "AQAAAAIAAYagAAAAED6NMviLL2arHtiYhoWGr4sgZ8Fshn5Zle16j09bcR35MFXSGYpE0wskAKdEiV6LYw==",
							SecurityStamp = "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F",
							ConcurrencyStamp = "605095b2-c70f-4f4d-b85c-b2adde79c0ec",
							PhoneNumber = "0000000001",
							PhoneNumberConfirmed = false,
							TwoFactorEnabled = false,
							LockoutEnd = DateTimeOffset.Now,
							LockoutEnabled = true,
							AccessFailedCount = 0,
							NumberOfPost = 5,
							IsRemoved = false
						},
					}
				);
		}
	}
}
