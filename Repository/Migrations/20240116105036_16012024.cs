using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _16012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserUserFollowing",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserUserFollowing",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserRole",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserRole",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserRefreshToken",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserRefreshToken",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserPostLiking",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserPostLiking",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserPostExploring",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserPostExploring",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserImage",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserImage",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserConversation",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserConversation",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserCommentLiking",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "UserCommentLiking",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "User",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "User",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Tag",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Tag",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "SwappingCommentContent",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "SwappingCommentContent",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "SwappingComment",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "SwappingComment",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Swapping",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Swapping",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Searching",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Searching",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Role",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Role",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PostTag",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "PostTag",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PostPostRequesting",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "PostPostRequesting",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PostImage",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "PostImage",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Post",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Post",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Message",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Message",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ConversationImage",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "ConversationImage",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Conversation",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Conversation",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Comment",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Comment",
                newName: "RemovedDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Category",
                newName: "IsRemoved");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Category",
                newName: "RemovedDate");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6091));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserUserFollowing",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserUserFollowing",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserRole",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserRole",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserRefreshToken",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserRefreshToken",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserPostLiking",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserPostLiking",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserPostExploring",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserPostExploring",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserImage",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserImage",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserConversation",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserConversation",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "UserCommentLiking",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "UserCommentLiking",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "User",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "User",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Tag",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Tag",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "SwappingCommentContent",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "SwappingCommentContent",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "SwappingComment",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "SwappingComment",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Swapping",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Swapping",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Searching",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Searching",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Role",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Role",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "PostTag",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "PostTag",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "PostPostRequesting",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "PostPostRequesting",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "PostImage",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "PostImage",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Post",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Post",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Message",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Message",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "ConversationImage",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "ConversationImage",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Conversation",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Conversation",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Comment",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Comment",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "RemovedDate",
                table: "Category",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Category",
                newName: "IsDeleted");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 13, 16, 8, 55, 686, DateTimeKind.Local).AddTicks(6727));
        }
    }
}
