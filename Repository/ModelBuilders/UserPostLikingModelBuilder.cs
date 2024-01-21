using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class UserPostLikingModelBuilder : IEntityTypeConfiguration<UserPostLiking>
	{
		public void Configure(EntityTypeBuilder<UserPostLiking> builder)
		{
			builder.HasKey(x => new { x.UserId,x.PostId });
		}
	}
}
