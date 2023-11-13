using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addIndexersToUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 44, 53, 9, DateTimeKind.Utc).AddTicks(991));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 44, 53, 9, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 44, 53, 9, DateTimeKind.Utc).AddTicks(993));

            migrationBuilder.CreateIndex(
                name: "createdDateIndexer",
                table: "User",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "emailIndexer",
                table: "User",
                column: "NormalizedEmail",
                unique: true,
                filter: "[NormalizedEmail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "fullNameIndexer",
                table: "User",
                column: "NormalizedFullName");

            migrationBuilder.CreateIndex(
                name: "userNameIndexer",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "createdDateIndexer",
                table: "User");

            migrationBuilder.DropIndex(
                name: "emailIndexer",
                table: "User");

            migrationBuilder.DropIndex(
                name: "fullNameIndexer",
                table: "User");

            migrationBuilder.DropIndex(
                name: "userNameIndexer",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 30, 59, 456, DateTimeKind.Utc).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 30, 59, 456, DateTimeKind.Utc).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 16, 30, 59, 456, DateTimeKind.Utc).AddTicks(6050));
        }
    }
}
