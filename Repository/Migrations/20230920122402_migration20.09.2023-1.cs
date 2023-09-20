using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class migration200920231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_Posts_OwnerId",
                table: "AppFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_Users_OwnerId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_OwnerId",
                table: "AppFiles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("08c492de-908b-4cda-ae9b-1374e4c9192c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("12fb765f-6381-4841-9c12-e706896b0d54"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6532d9c0-17df-457b-8897-c6de143ab41e"));

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AppFiles");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("161bcef8-96bf-4548-879b-8e545fc76afb"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3718), "client", null },
                    { new Guid("19da35b9-82f0-4d56-b8cf-88efc7806bf1"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3722), "admin", null },
                    { new Guid("c5038766-b8df-48e1-a769-5c19dbe291c2"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3721), "user", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_PostId",
                table: "AppFiles",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_UserId",
                table: "AppFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_Posts_PostId",
                table: "AppFiles",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_Users_UserId",
                table: "AppFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_Posts_PostId",
                table: "AppFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFiles_Users_UserId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_PostId",
                table: "AppFiles");

            migrationBuilder.DropIndex(
                name: "IX_AppFiles_UserId",
                table: "AppFiles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("161bcef8-96bf-4548-879b-8e545fc76afb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("19da35b9-82f0-4d56-b8cf-88efc7806bf1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c5038766-b8df-48e1-a769-5c19dbe291c2"));

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppFiles");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "AppFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("08c492de-908b-4cda-ae9b-1374e4c9192c"), new DateTime(2023, 9, 20, 11, 42, 41, 275, DateTimeKind.Utc).AddTicks(5405), "admin", null },
                    { new Guid("12fb765f-6381-4841-9c12-e706896b0d54"), new DateTime(2023, 9, 20, 11, 42, 41, 275, DateTimeKind.Utc).AddTicks(5393), "client", null },
                    { new Guid("6532d9c0-17df-457b-8897-c6de143ab41e"), new DateTime(2023, 9, 20, 11, 42, 41, 275, DateTimeKind.Utc).AddTicks(5395), "user", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_OwnerId",
                table: "AppFiles",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_Posts_OwnerId",
                table: "AppFiles",
                column: "OwnerId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFiles_Users_OwnerId",
                table: "AppFiles",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
