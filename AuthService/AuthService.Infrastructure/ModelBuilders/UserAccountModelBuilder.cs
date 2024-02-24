using AuthService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.ModelBuilders
{
    public class UserAccountModelBuilder : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {

            builder
                .HasMany(x => x.UsersTheEntiyBlocked)
                .WithOne()
                .HasForeignKey(x => x.BlockerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.UsersWhoBlockedTheEntity)
                .WithOne()
                .HasForeignKey(x => x.BlockedId);

        }
    }
}
