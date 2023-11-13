﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Contexts;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231112200647_removePublishDateFromPostTable")]
    partial class removePublishDateFromPostTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application.Entities.AppFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AppFile");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppFile");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Application.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e17dac4e-3930-457e-858b-96de54391aec"),
                            CreatedDate = new DateTime(2023, 11, 12, 23, 6, 47, 418, DateTimeKind.Local).AddTicks(3691),
                            Name = "Kitaplar",
                            NormalizedName = "KITAPLAR"
                        });
                });

            modelBuilder.Entity("Application.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Application.Entities.Credit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditType")
                        .HasColumnType("int");

                    b.Property<decimal>("SAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("VAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("Application.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountOfImages")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedDate")
                        .IsDescending()
                        .HasDatabaseName("createdDateIndexer");

                    b.HasIndex("NormalizedTitle")
                        .HasDatabaseName("titleIndexer");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Application.Entities.PostPostRequesting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
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

                    b.ToTable("PostPostRequesting");
                });

            modelBuilder.Entity("Application.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                            CreatedDate = new DateTime(2023, 11, 12, 20, 6, 47, 418, DateTimeKind.Utc).AddTicks(3796),
                            Name = "client"
                        },
                        new
                        {
                            Id = new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                            CreatedDate = new DateTime(2023, 11, 12, 20, 6, 47, 418, DateTimeKind.Utc).AddTicks(3803),
                            Name = "user"
                        },
                        new
                        {
                            Id = new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                            CreatedDate = new DateTime(2023, 11, 12, 20, 6, 47, 418, DateTimeKind.Utc).AddTicks(3804),
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Application.Entities.Searching", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Searching");
                });

            modelBuilder.Entity("Application.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedFullName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate")
                        .IsDescending()
                        .HasDatabaseName("createdDateIndexer");

                    b.HasIndex("NormalizedEmail")
                        .IsUnique()
                        .HasDatabaseName("emailIndexer")
                        .HasFilter("[NormalizedEmail] IS NOT NULL");

                    b.HasIndex("NormalizedFullName")
                        .HasDatabaseName("fullNameIndexer");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("userNameIndexer")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Application.Entities.UserCommentLiking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCommentLiking");
                });

            modelBuilder.Entity("Application.Entities.UserPostFollowing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPostFollowing");
                });

            modelBuilder.Entity("Application.Entities.UserPostLiking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPostLiking");
                });

            modelBuilder.Entity("Application.Entities.UserPostViewing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPostViewing");
                });

            modelBuilder.Entity("Application.Entities.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRefreshToken");
                });

            modelBuilder.Entity("Application.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Application.Entities.UserUserFollowing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FollowedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FollowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FollowedId");

                    b.HasIndex("FollowerId");

                    b.ToTable("UserUserFollowing");
                });

            modelBuilder.Entity("Application.Entities.PostImage", b =>
                {
                    b.HasBaseType("Application.Entities.AppFile");

                    b.Property<Guid?>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("PostImage");
                });

            modelBuilder.Entity("Application.Entities.ProfileImage", b =>
                {
                    b.HasBaseType("Application.Entities.AppFile");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("ProfileImage");
                });

            modelBuilder.Entity("Application.Entities.Comment", b =>
                {
                    b.HasOne("Application.Entities.Comment", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Application.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.Credit", b =>
                {
                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("Credits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.Post", b =>
                {
                    b.HasOne("Application.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.PostPostRequesting", b =>
                {
                    b.HasOne("Application.Entities.Post", "Requested")
                        .WithMany("Requesters")
                        .HasForeignKey("RequestedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.Post", "Requester")
                        .WithMany("Requesteds")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Requested");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("Application.Entities.Searching", b =>
                {
                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("Searchings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserCommentLiking", b =>
                {
                    b.HasOne("Application.Entities.Comment", "Comment")
                        .WithMany("UsersWhoLiked")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("LikedComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserPostFollowing", b =>
                {
                    b.HasOne("Application.Entities.Post", "Post")
                        .WithMany("UsersFollowingThePost")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("PostsFollowedByTheUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserPostLiking", b =>
                {
                    b.HasOne("Application.Entities.Post", "Post")
                        .WithMany("UsersWhoLiked")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserPostViewing", b =>
                {
                    b.HasOne("Application.Entities.Post", "Post")
                        .WithMany("UsersWhoViewed")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("ViewedPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserRefreshToken", b =>
                {
                    b.HasOne("Application.Entities.User", "User")
                        .WithOne("UserRefreshToken")
                        .HasForeignKey("Application.Entities.UserRefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Application.ValueObjects.Token", "Token", b1 =>
                        {
                            b1.Property<Guid>("UserRefreshTokenId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("exprationDateOfRefreshToken");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("refreshToken");

                            b1.HasKey("UserRefreshTokenId");

                            b1.ToTable("UserRefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserRefreshTokenId");
                        });

                    b.Navigation("Token")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserRole", b =>
                {
                    b.HasOne("Application.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.UserUserFollowing", b =>
                {
                    b.HasOne("Application.Entities.User", "Followed")
                        .WithMany("Followers")
                        .HasForeignKey("FollowedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Application.Entities.User", "Follower")
                        .WithMany("Followeds")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Followed");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("Application.Entities.PostImage", b =>
                {
                    b.HasOne("Application.Entities.Post", "Post")
                        .WithMany("PostImages")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Application.Entities.ProfileImage", b =>
                {
                    b.HasOne("Application.Entities.User", "User")
                        .WithMany("ProfileImages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Application.Entities.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Application.Entities.Comment", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("UsersWhoLiked");
                });

            modelBuilder.Entity("Application.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostImages");

                    b.Navigation("Requesteds");

                    b.Navigation("Requesters");

                    b.Navigation("UsersFollowingThePost");

                    b.Navigation("UsersWhoLiked");

                    b.Navigation("UsersWhoViewed");
                });

            modelBuilder.Entity("Application.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Application.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Credits");

                    b.Navigation("Followeds");

                    b.Navigation("Followers");

                    b.Navigation("LikedComments");

                    b.Navigation("LikedPosts");

                    b.Navigation("Posts");

                    b.Navigation("PostsFollowedByTheUser");

                    b.Navigation("ProfileImages");

                    b.Navigation("Roles");

                    b.Navigation("Searchings");

                    b.Navigation("UserRefreshToken")
                        .IsRequired();

                    b.Navigation("ViewedPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
