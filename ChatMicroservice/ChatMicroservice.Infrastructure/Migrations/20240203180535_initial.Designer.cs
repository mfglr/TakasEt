﻿// <auto-generated />
using System;
using ChatMicroservice.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    [Migration("20240203180535_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatMicroservice.Domain.ConversationAggregate.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.ConversationAggregate.ConversationUserRemoving", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.ToTable("ConversationUserRemoving");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.GroupImage", b =>
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

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupImage");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.GroupUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizeContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfImages")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("GroupId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageImage", b =>
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

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageImage");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserLiking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageUserLiking");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserRemoving", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageUserRemoving");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserViewing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageUserViewing");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.ConversationAggregate.ConversationUserRemoving", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.ConversationAggregate.Conversation", null)
                        .WithMany("UsersWhoRemovedTheEntity")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.GroupImage", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.GroupAggregate.Group", null)
                        .WithMany("Images")
                        .HasForeignKey("GroupId");

                    b.OwnsOne("SharedLibrary.ValueObjects.ContainerName", "ContainerName", b1 =>
                        {
                            b1.Property<Guid>("GroupImageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ContainerName");

                            b1.HasKey("GroupImageId");

                            b1.ToTable("GroupImage");

                            b1.WithOwner()
                                .HasForeignKey("GroupImageId");
                        });

                    b.OwnsOne("SharedLibrary.ValueObjects.Dimension", "Dimension", b1 =>
                        {
                            b1.Property<Guid>("GroupImageId")
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

                            b1.HasKey("GroupImageId");

                            b1.ToTable("GroupImage");

                            b1.WithOwner()
                                .HasForeignKey("GroupImageId");
                        });

                    b.Navigation("ContainerName")
                        .IsRequired();

                    b.Navigation("Dimension")
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.GroupUser", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.GroupAggregate.Group", null)
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.Message", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.ConversationAggregate.Conversation", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId");

                    b.HasOne("ChatMicroservice.Domain.GroupAggregate.Group", null)
                        .WithMany("Messages")
                        .HasForeignKey("GroupId");

                    b.OwnsOne("ChatMicroservice.Domain.MessageEntity.MessageState", "MessageState", b1 =>
                        {
                            b1.Property<Guid>("MessageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Status")
                                .HasColumnType("int")
                                .HasColumnName("Status");

                            b1.HasKey("MessageId");

                            b1.ToTable("Messages");

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.Navigation("MessageState")
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageImage", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.MessageEntity.Message", null)
                        .WithMany("MessageImages")
                        .HasForeignKey("MessageId");

                    b.OwnsOne("SharedLibrary.ValueObjects.ContainerName", "ContainerName", b1 =>
                        {
                            b1.Property<Guid>("MessageImageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ContainerName");

                            b1.HasKey("MessageImageId");

                            b1.ToTable("MessageImage");

                            b1.WithOwner()
                                .HasForeignKey("MessageImageId");
                        });

                    b.OwnsOne("SharedLibrary.ValueObjects.Dimension", "Dimension", b1 =>
                        {
                            b1.Property<Guid>("MessageImageId")
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

                            b1.HasKey("MessageImageId");

                            b1.ToTable("MessageImage");

                            b1.WithOwner()
                                .HasForeignKey("MessageImageId");
                        });

                    b.Navigation("ContainerName")
                        .IsRequired();

                    b.Navigation("Dimension")
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserLiking", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.MessageEntity.Message", null)
                        .WithMany("UsersWhoLikedTheEntity")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserRemoving", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.MessageEntity.Message", null)
                        .WithMany("UsersWhoRemovedTheEntity")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.MessageUserViewing", b =>
                {
                    b.HasOne("ChatMicroservice.Domain.MessageEntity.Message", null)
                        .WithMany("UsersWhoViewedTheEntiy")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChatMicroservice.Domain.ConversationAggregate.Conversation", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("UsersWhoRemovedTheEntity");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.GroupAggregate.Group", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Messages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ChatMicroservice.Domain.MessageEntity.Message", b =>
                {
                    b.Navigation("MessageImages");

                    b.Navigation("UsersWhoLikedTheEntity");

                    b.Navigation("UsersWhoRemovedTheEntity");

                    b.Navigation("UsersWhoViewedTheEntiy");
                });
#pragma warning restore 612, 618
        }
    }
}
