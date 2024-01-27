using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "UserCommentLiking");

            migrationBuilder.DropTable(
                name: "UserConversation");

            migrationBuilder.DropTable(
                name: "UserPostExploring");

            migrationBuilder.DropTable(
                name: "UserPostLiking");

            migrationBuilder.DropTable(
                name: "UserStoryImageLiking");

            migrationBuilder.DropTable(
                name: "UserStoryImageViewing");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfStoryImage",
                table: "Story",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizeContent",
                table: "Message",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Category",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CommentUserLiking",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentUserLiking", x => new { x.CommentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CommentUserLiking_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentUserLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConversationUser",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationUser", x => new { x.ConversationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ConversationUser_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConversationUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageUserLiking",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUserLiking", x => new { x.MessageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MessageUserLiking_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MessageUserViewing",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUserViewing", x => new { x.MessageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MessageUserViewing_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostUserExploring",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserExploring", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostUserExploring_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserExploring_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostUserLiking",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserLiking", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostUserLiking_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostUserLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostUserViewing",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserViewing", x => new { x.PostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PostUserViewing_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryImageUserLiking",
                columns: table => new
                {
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryImageUserLiking", x => new { x.StoryImageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StoryImageUserLiking_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoryImageUserLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoryImageUserViewing",
                columns: table => new
                {
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryImageUserViewing", x => new { x.StoryImageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StoryImageUserViewing_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoryImageUserViewing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserUserViewing",
                columns: table => new
                {
                    ViewerId = table.Column<int>(type: "int", nullable: false),
                    ViewedId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserViewing", x => new { x.ViewerId, x.ViewedId });
                    table.ForeignKey(
                        name: "FK_UserUserViewing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUserViewing_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentUserLiking_UserId",
                table: "CommentUserLiking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationUser_UserId",
                table: "ConversationUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserExploring_UserId",
                table: "PostUserExploring",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserLiking_UserId",
                table: "PostUserLiking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryImageUserLiking_UserId",
                table: "StoryImageUserLiking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryImageUserViewing_UserId",
                table: "StoryImageUserViewing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserViewing_UserId",
                table: "UserUserViewing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserViewing_UserId1",
                table: "UserUserViewing",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "CommentUserLiking");

            migrationBuilder.DropTable(
                name: "ConversationUser");

            migrationBuilder.DropTable(
                name: "MessageUserLiking");

            migrationBuilder.DropTable(
                name: "MessageUserViewing");

            migrationBuilder.DropTable(
                name: "PostUserExploring");

            migrationBuilder.DropTable(
                name: "PostUserLiking");

            migrationBuilder.DropTable(
                name: "PostUserViewing");

            migrationBuilder.DropTable(
                name: "StoryImageUserLiking");

            migrationBuilder.DropTable(
                name: "StoryImageUserViewing");

            migrationBuilder.DropTable(
                name: "UserUserViewing");

            migrationBuilder.DropColumn(
                name: "NumberOfStoryImage",
                table: "Story");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Conversation");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizeContent",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)");

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.CreateTable(
                name: "UserCommentLiking",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentLiking", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_UserCommentLiking_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCommentLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserConversation",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ConversationId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConversation", x => new { x.UserId, x.ConversationId });
                    table.ForeignKey(
                        name: "FK_UserConversation_Conversation_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserConversation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPostExploring",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostExploring", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPostExploring_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostExploring_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPostLiking",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostLiking", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPostLiking_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPostLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserStoryImageLiking",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryImageLiking", x => new { x.UserId, x.StoryImageId });
                    table.ForeignKey(
                        name: "FK_UserStoryImageLiking_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserStoryImageLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserStoryImageViewing",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryImageViewing", x => new { x.UserId, x.StoryImageId });
                    table.ForeignKey(
                        name: "FK_UserStoryImageViewing_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserStoryImageViewing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentLiking_CommentId",
                table: "UserCommentLiking",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_ConversationId",
                table: "UserConversation",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostExploring_PostId",
                table: "UserPostExploring",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostLiking_PostId",
                table: "UserPostLiking",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryImageLiking_StoryImageId",
                table: "UserStoryImageLiking",
                column: "StoryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryImageViewing_StoryImageId",
                table: "UserStoryImageViewing",
                column: "StoryImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Category_CategoryId",
                table: "Post",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
