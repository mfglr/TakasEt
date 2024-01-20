using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class RequestingModelBuilder : IEntityTypeConfiguration<Requesting>
	{
		public void Configure(EntityTypeBuilder<Requesting> builder)
		{
			builder.OwnsOne(
				x => x.Status,
				r => {
					r.Property(status => status.Status).HasColumnName("status");
				}
			);
		}
	}
}
