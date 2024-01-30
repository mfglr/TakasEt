using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class GroupModelBuilder : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder
				.HasMany(x => x.Messages)
				.WithOne(x => x.Group)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.NoAction);
			
			builder
				.HasMany(x => x.Users)
				.WithOne(x => x.Group)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(x => x.Images)
				.WithOne(x => x.Group)
				.HasForeignKey(x => x.GroupId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
