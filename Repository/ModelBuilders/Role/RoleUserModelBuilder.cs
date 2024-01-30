using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class RoleUserModelBuilder : IEntityTypeConfiguration<RoleUser>
	{
		public void Configure(EntityTypeBuilder<RoleUser> builder)
		{
			builder.HasKey(x => new { x.RoleId, x.UserId});
		}
	}
}
