using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class SwappingModelBuilder : IEntityTypeConfiguration<Swapping>
	{
		public void Configure(EntityTypeBuilder<Swapping> builder)
		{
			builder
				.HasMany(x => x.SwappingComments)
				.WithOne(x => x.Swapping)
				.HasForeignKey(x => x.SwappingId)
				.OnDelete(DeleteBehavior.NoAction);
		}

	}
}
