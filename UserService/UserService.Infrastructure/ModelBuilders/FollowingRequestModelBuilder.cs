using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.UserAggregate;

namespace UserService.Infrastructure.ModelBuilders
{
    internal class FollowingRequestModelBuilder : IEntityTypeConfiguration<FollowingRequest>
    {
        public void Configure(EntityTypeBuilder<FollowingRequest> builder)
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
