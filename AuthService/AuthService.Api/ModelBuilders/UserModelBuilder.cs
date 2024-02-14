//using AuthService.Domain.UserAggregate;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AuthService.Infrastructure.ModelBuilders
//{
//    public class UserModelBuilder : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {

//            builder.Property(x => x.Name).HasColumnType("varchar(100)");
//            builder.Property(x => x.LastName).HasColumnType("varchar(100)");
//            builder.Property(x => x.NormalizedFullName).HasColumnType("varchar(200)");
//            builder.HasIndex(x => x.NormalizedFullName).HasDatabaseName("FullNameIndexer");


//            builder
//                .HasMany(x => x.UsersWhoViewedTheEntity)
//                .WithOne()
//                .HasForeignKey(x => x.ViewerId);
//            builder
//                .HasMany(x => x.UsersTheEntityViewed)
//                .WithOne()
//                .HasForeignKey(x => x.ViewedId);

//            builder
//                .HasMany(x => x.UsersWhoBlockedTheEntity)
//                .WithOne()
//                .HasForeignKey(x => x.BlockerId);
//            builder
//                .HasMany(x => x.UsersTheEntityBlocked)
//                .WithOne()
//                .HasForeignKey(x => x.BlockedId);

//            builder
//               .HasMany(x => x.UsersWhoFollowedTheEntity)
//               .WithOne()
//               .HasForeignKey(x => x.FollowerId);
//            builder
//               .HasMany(x => x.UsersTheEntityFollowed)
//               .WithOne()
//               .HasForeignKey(x => x.FollowingId);

//        }
//    }
//}
