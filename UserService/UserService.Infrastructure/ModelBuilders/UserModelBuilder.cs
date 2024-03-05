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
            builder.HasIndex(x => x.NormalizedFullName).HasDatabaseName("FullNameIndexer");
            builder.HasIndex(x => x.CreatedDate).HasDatabaseName("CreatedDateIndexer");
            builder.HasIndex(x => x.UserName).HasDatabaseName("UserNameIndexer");
            builder.HasIndex(x => x.Email).HasDatabaseName("EmailIndexer");

            builder
                .HasMany(x => x.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasMany(x => x.UsersWhoViewedTheEntity)
                .WithOne()
                .HasForeignKey(x => x.ViewedId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheEntityViewed)
                .WithOne()
                .HasForeignKey(x => x.ViewerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.UsersWhoFollowedTheEntity)
                .WithOne()
                .HasForeignKey(x => x.FollowingId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheEntityFollowed)
                .WithOne()
                .HasForeignKey(x => x.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.UsersWhoWantToFollowTheUser)
                .WithOne()
                .HasForeignKey(x => x.RequestedId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasMany(x => x.UsersTheUserWantsToFollow)
                .WithOne()
                .HasForeignKey(x => x.RequesterId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
