using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Repository.ModelBuilders
{
	public class RequestingModelBuilder : IEntityTypeConfiguration<Requesting>
	{
		public void Configure(EntityTypeBuilder<Requesting> builder)
		{
			builder.OwnsOne(
				x => x.Status,
				r => {
					r.Property(status => status.Status).HasColumnName("Status");
				}
			);
			builder.HasKey(x => new { x.RequesterId, x.RequestedId });
		}
	}
}
