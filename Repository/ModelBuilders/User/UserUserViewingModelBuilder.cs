using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class UserUserViewingModelBuilder : IEntityTypeConfiguration<UserUserViewing>
	{
		public void Configure(EntityTypeBuilder<UserUserViewing> builder)
		{
			builder.HasKey(x => new {x.ViewerId,x.ViewedId});
		}
	}
}
