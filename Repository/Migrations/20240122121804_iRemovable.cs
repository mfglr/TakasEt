using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class iRemovable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserPostLiking");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserPostLiking");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserPostExploring");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserPostExploring");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserConversation");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserConversation");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserCommentLiking");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "UserCommentLiking");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Swapping");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "Swapping");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Requesting");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "Requesting");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "PostTag");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Following");

            migrationBuilder.DropColumn(
                name: "RemovedDate",
                table: "Following");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(6906));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 18, 4, 342, DateTimeKind.Local).AddTicks(7022));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserPostLiking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserPostLiking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserPostExploring",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserPostExploring",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserConversation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserConversation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserCommentLiking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "UserCommentLiking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Swapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "Swapping",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Requesting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "Requesting",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "PostTag",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "PostTag",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Following",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedDate",
                table: "Following",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(190));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(194));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 22, 15, 8, 13, 398, DateTimeKind.Local).AddTicks(409));
        }
    }
}
