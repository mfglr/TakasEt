﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService.Infrastructure;

#nullable disable

namespace UserService.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserService.Domain.UserAggregate.Following", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Following");
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.FollowingRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestedId");

                    b.HasIndex("RequesterId");

                    b.ToTable("FollowingRequest");
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrivateProfile")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedFullName")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("CreatedDateIndexer");

                    b.HasIndex("Email")
                        .HasDatabaseName("EmailIndexer");

                    b.HasIndex("NormalizedFullName")
                        .HasDatabaseName("FullNameIndexer");

                    b.HasIndex("UserName")
                        .HasDatabaseName("UserNameIndexer");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.UserImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserImage");
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.Viewing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ViewedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ViewerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ViewedId");

                    b.HasIndex("ViewerId");

                    b.ToTable("Viewing");
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.Following", b =>
                {
                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersTheEntityFollowed")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersWhoFollowedTheEntity")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.FollowingRequest", b =>
                {
                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersWhoWantToFollowTheUser")
                        .HasForeignKey("RequestedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersTheUserWantsToFollow")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("UserService.Domain.UserAggregate.FollowingRequestState", "State", b1 =>
                        {
                            b1.Property<Guid>("FollowingRequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Status")
                                .HasColumnType("int")
                                .HasColumnName("Status");

                            b1.HasKey("FollowingRequestId");

                            b1.ToTable("FollowingRequest");

                            b1.WithOwner()
                                .HasForeignKey("FollowingRequestId");
                        });

                    b.Navigation("State")
                        .IsRequired();
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.UserImage", b =>
                {
                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("Images")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("SharedLibrary.ValueObjects.ContainerName", "ContainerName", b1 =>
                        {
                            b1.Property<Guid>("UserImageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ContainerName");

                            b1.HasKey("UserImageId");

                            b1.ToTable("UserImage");

                            b1.WithOwner()
                                .HasForeignKey("UserImageId");
                        });

                    b.OwnsOne("SharedLibrary.ValueObjects.Dimension", "Dimension", b1 =>
                        {
                            b1.Property<Guid>("UserImageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<float>("AspectRatio")
                                .HasColumnType("real")
                                .HasColumnName("AspectRatio");

                            b1.Property<int>("Height")
                                .HasColumnType("int")
                                .HasColumnName("Height");

                            b1.Property<int>("Width")
                                .HasColumnType("int")
                                .HasColumnName("Width");

                            b1.HasKey("UserImageId");

                            b1.ToTable("UserImage");

                            b1.WithOwner()
                                .HasForeignKey("UserImageId");
                        });

                    b.Navigation("ContainerName")
                        .IsRequired();

                    b.Navigation("Dimension")
                        .IsRequired();
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.Viewing", b =>
                {
                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersWhoViewedTheEntity")
                        .HasForeignKey("ViewedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UserService.Domain.UserAggregate.User", null)
                        .WithMany("UsersTheEntityViewed")
                        .HasForeignKey("ViewerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("UserService.Domain.UserAggregate.User", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("UsersTheEntityFollowed");

                    b.Navigation("UsersTheEntityViewed");

                    b.Navigation("UsersTheUserWantsToFollow");

                    b.Navigation("UsersWhoFollowedTheEntity");

                    b.Navigation("UsersWhoViewedTheEntity");

                    b.Navigation("UsersWhoWantToFollowTheUser");
                });
#pragma warning restore 612, 618
        }
    }
}
