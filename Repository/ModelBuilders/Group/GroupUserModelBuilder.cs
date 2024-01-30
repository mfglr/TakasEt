using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class GroupUserModelBuilder : IEntityTypeConfiguration<GroupUser>
	{
		public void Configure(EntityTypeBuilder<GroupUser> builder)
		{
			builder.HasKey(x => new { x.GroupId, x.UserId });
		}
	}
}
