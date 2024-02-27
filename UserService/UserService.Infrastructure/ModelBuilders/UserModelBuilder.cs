using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.UserAggregate;

namespace UserService.Infrastructure.ModelBuilders
{
    internal class UserModelBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Property(x => x.LastName).HasColumnType("varchar(100)");
            builder.Property(x => x.NormalizedFullName).HasColumnType("varchar(200)");
            builder.HasIndex(x => x.NormalizedFullName).HasDatabaseName("fullNameIndexer");
            builder.HasIndex(x => x.CreatedDate).HasDatabaseName("CreatedDateIndexer");

            builder
                .HasMany(x => x.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(x => x.UsersWhoViewedTheEntity)
                .WithOne()
                .HasForeignKey(x => x.ViewerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheEntityViewed)
                .WithOne()
                .HasForeignKey(x => x.ViewedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.UsersWhoFollowedTheEntity)
                .WithOne()
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheEntityFollowed)
                .WithOne()
                .HasForeignKey(x => x.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
