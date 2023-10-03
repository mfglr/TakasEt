using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.ModelBuilders
{
	public class AppFileModelBuilder : IEntityTypeConfiguration<AppFile>
	{
		public void Configure(EntityTypeBuilder<AppFile> builder)
		{
		}
	}
}
