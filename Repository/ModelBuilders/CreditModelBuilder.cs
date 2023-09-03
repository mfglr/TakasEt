using Application.Entities;
using Application.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	internal class CreditModelBuilder : IEntityTypeConfiguration<Credit>
	{
		public void Configure(EntityTypeBuilder<Credit> builder)
		{

			builder.Property(x => x.CreditType).HasConversion(x => x.Value, v => new CreditType());
			builder.Property(x => x.SAmount).HasColumnType("decimal(18,2)");
			builder.Property(x => x.VAmount).HasColumnType("decimal(18,2)");

		}
	}
}
