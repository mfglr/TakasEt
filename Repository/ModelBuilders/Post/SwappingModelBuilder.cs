using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class SwappingModelBuilder : IEntityTypeConfiguration<Swapping>
	{
		public void Configure(EntityTypeBuilder<Swapping> builder)
		{
			builder
				.HasMany(x => x.SwappingComments)
				.WithOne(x => x.Swapping)
				.HasForeignKey(x => new { x.RequesterId, x.RequestedId })
				.OnDelete(DeleteBehavior.NoAction);

			builder.OwnsOne(
				x => x.Status,
				s => {
					s.Property(status => status.Status).HasColumnName("Status");
				}
			);

			builder.HasKey(x => new { x.RequesterId, x.RequestedId });
		}

	}
}
