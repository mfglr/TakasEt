using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.UserAggregate;

namespace UserService.Infrastructure.ModelBuilders
{
    internal class FollowingModelBuilder : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.OwnsOne(
                following => following.State,
                builder => {
                    builder.Property(followingState => followingState.Status).HasColumnName("Status");
                }
            );
        }
    }
}
