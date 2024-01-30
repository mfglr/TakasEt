using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	internal class UserRefreshTokenModelBuilder : IEntityTypeConfiguration<UserRefreshToken>
	{
		public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
		{
		}
	}
}
