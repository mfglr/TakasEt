using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class UserRefreshTokenModelBuilder : IEntityTypeConfiguration<UserRefreshToken>
	{
		public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
		{
			builder.OwnsOne(x => x.Token, t =>
			{
				t.Property(p => p.Value).HasColumnName("refreshToken");
				t.Property(p => p.ExpirationDate).HasColumnName("exprationDateOfRefreshToken");

			});
		}
	}
}
