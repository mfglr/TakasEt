﻿// <auto-generated />
using System;
using ConversationService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240306033813_ChangeNameOf_DateTimeOfLastMessageReceived_ColumnTo_DateTimeOfLastMessage")]
    partial class ChangeNameOf_DateTimeOfLastMessageReceived_ColumnTo_DateTimeOfLastMessage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeOfLastMessage")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId2")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("CreatedDateIndexer");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("NormalizeContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfImages")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SavedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ViewedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("CreatedDate")
                        .HasDatabaseName("CreatedDateIndexer");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.MessageImage", b =>
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

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageImage");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.MessageUserLiking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("ConversationService.Domain.UserConnectionAggregate.UserConnection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserConnections");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.Message", b =>
                {
                    b.HasOne("ConversationService.Domain.ConversationAggregate.Conversation", null)
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId");

                    b.HasOne("ConversationService.Domain.UserConnectionAggregate.UserConnection", "Sender")
                        .WithMany("Messages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("ConversationService.Domain.ConversationAggregate.MessageState", "MessageState", b1 =>
                        {
                            b1.Property<string>("MessageId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("Status")
                                .HasColumnType("int");

                            b1.HasKey("MessageId");

                            b1.ToTable("Messages");

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.Navigation("MessageState")
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.MessageImage", b =>
                {
                    b.HasOne("ConversationService.Domain.ConversationAggregate.Message", null)
                        .WithMany("Images")
                        .HasForeignKey("MessageId");

                    b.OwnsOne("SharedLibrary.ValueObjects.ContainerName", "ContainerName", b1 =>
                        {
                            b1.Property<Guid>("MessageImageId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

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
                                .HasColumnType("real");

                            b1.Property<int>("Height")
                                .HasColumnType("int");

                            b1.Property<int>("Width")
                                .HasColumnType("int");

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

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.MessageUserLiking", b =>
                {
                    b.HasOne("ConversationService.Domain.ConversationAggregate.Message", null)
                        .WithMany("UsersWhoLikedTheEntity")
                        .HasForeignKey("MessageId");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ConversationService.Domain.ConversationAggregate.Message", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("UsersWhoLikedTheEntity");
                });

            modelBuilder.Entity("ConversationService.Domain.UserConnectionAggregate.UserConnection", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
