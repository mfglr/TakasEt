using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _21012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwappingComment_Swapping_SwappingId",
                table: "SwappingComment");

            migrationBuilder.DropTable(
                name: "UserUserFollowing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostLiking",
                table: "UserPostLiking");

            migrationBuilder.DropIndex(
                name: "IX_UserPostLiking_UserId",
                table: "UserPostLiking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostExploring",
                table: "UserPostExploring");

            migrationBuilder.DropIndex(
                name: "IX_UserPostExploring_UserId",
                table: "UserPostExploring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation");

            migrationBuilder.DropIndex(
                name: "IX_UserConversation_UserId",
                table: "UserConversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCommentLiking",
                table: "UserCommentLiking");

            migrationBuilder.DropIndex(
                name: "IX_UserCommentLiking_UserId",
                table: "UserCommentLiking");

            migrationBuilder.DropIndex(
                name: "IX_SwappingComment_SwappingId",
                table: "SwappingComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swapping",
                table: "Swapping");

            migrationBuilder.DropIndex(
                name: "IX_Swapping_RequesterId",
                table: "Swapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requesting",
                table: "Requesting");

            migrationBuilder.DropIndex(
                name: "IX_Requesting_RequesterId",
                table: "Requesting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.DropIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPostLiking");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPostExploring");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserConversation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCommentLiking");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Swapping");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Requesting");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostTag");

            migrationBuilder.RenameColumn(
                name: "SwappingId",
                table: "SwappingComment",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Swapping",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Requesting",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "RequestedId",
                table: "SwappingComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostLiking",
                table: "UserPostLiking",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostExploring",
                table: "UserPostExploring",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation",
                columns: new[] { "UserId", "ConversationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCommentLiking",
                table: "UserCommentLiking",
                columns: new[] { "UserId", "CommentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swapping",
                table: "Swapping",
                columns: new[] { "RequesterId", "RequestedId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requesting",
                table: "Requesting",
                columns: new[] { "RequesterId", "RequestedId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    FollowingId = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_Following_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Following_User_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 21, 15, 47, 12, 802, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.CreateIndex(
                name: "IX_SwappingComment_RequesterId_RequestedId",
                table: "SwappingComment",
                columns: new[] { "RequesterId", "RequestedId" });

            migrationBuilder.CreateIndex(
                name: "IX_Following_FollowingId",
                table: "Following",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwappingComment_Swapping_RequesterId_RequestedId",
                table: "SwappingComment",
                columns: new[] { "RequesterId", "RequestedId" },
                principalTable: "Swapping",
                principalColumns: new[] { "RequesterId", "RequestedId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwappingComment_Swapping_RequesterId_RequestedId",
                table: "SwappingComment");

            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostLiking",
                table: "UserPostLiking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPostExploring",
                table: "UserPostExploring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCommentLiking",
                table: "UserCommentLiking");

            migrationBuilder.DropIndex(
                name: "IX_SwappingComment_RequesterId_RequestedId",
                table: "SwappingComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Swapping",
                table: "Swapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requesting",
                table: "Requesting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "RequestedId",
                table: "SwappingComment");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "SwappingComment",
                newName: "SwappingId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Swapping",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Requesting",
                newName: "status");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRole",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPostLiking",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPostExploring",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserConversation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserCommentLiking",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Swapping",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Requesting",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PostTag",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostLiking",
                table: "UserPostLiking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPostExploring",
                table: "UserPostExploring",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConversation",
                table: "UserConversation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCommentLiking",
                table: "UserCommentLiking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Swapping",
                table: "Swapping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requesting",
                table: "Requesting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserUserFollowing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<int>(type: "int", nullable: false),
                    FollowingId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserFollowing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUserFollowing_User_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserUserFollowing_User_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostLiking_UserId",
                table: "UserPostLiking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostExploring_UserId",
                table: "UserPostExploring",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_UserId",
                table: "UserConversation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommentLiking_UserId",
                table: "UserCommentLiking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SwappingComment_SwappingId",
                table: "SwappingComment",
                column: "SwappingId");

            migrationBuilder.CreateIndex(
                name: "IX_Swapping_RequesterId",
                table: "Swapping",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Requesting_RequesterId",
                table: "Requesting",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostId",
                table: "PostTag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserFollowing_FollowerId",
                table: "UserUserFollowing",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserFollowing_FollowingId",
                table: "UserUserFollowing",
                column: "FollowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwappingComment_Swapping_SwappingId",
                table: "SwappingComment",
                column: "SwappingId",
                principalTable: "Swapping",
                principalColumn: "Id");
        }
    }
}
