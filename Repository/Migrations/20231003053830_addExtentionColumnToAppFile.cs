using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addExtentionColumnToAppFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0c1e278b-bd0c-491a-8e82-7af02b2da825"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("429926d0-5332-4afe-b8b1-dda6aba1a4b0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d7713736-c232-4eb3-82c0-5d20d2483409"));

            migrationBuilder.AddColumn<string>(
                name: "Extention",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("710bf3dc-c626-42d7-b540-61a8df705bcf"), new DateTime(2023, 10, 3, 5, 38, 29, 950, DateTimeKind.Utc).AddTicks(6277), "client", null },
                    { new Guid("8f420592-16c0-4699-9cf7-cb27bb59bf54"), new DateTime(2023, 10, 3, 5, 38, 29, 950, DateTimeKind.Utc).AddTicks(6280), "admin", null },
                    { new Guid("8f78f4d4-9605-4fe9-b52c-ded213682e78"), new DateTime(2023, 10, 3, 5, 38, 29, 950, DateTimeKind.Utc).AddTicks(6279), "user", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("710bf3dc-c626-42d7-b540-61a8df705bcf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f420592-16c0-4699-9cf7-cb27bb59bf54"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f78f4d4-9605-4fe9-b52c-ded213682e78"));

            migrationBuilder.DropColumn(
                name: "Extention",
                table: "AppFiles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0c1e278b-bd0c-491a-8e82-7af02b2da825"), new DateTime(2023, 9, 29, 14, 52, 47, 696, DateTimeKind.Utc).AddTicks(1240), "client", null },
                    { new Guid("429926d0-5332-4afe-b8b1-dda6aba1a4b0"), new DateTime(2023, 9, 29, 14, 52, 47, 696, DateTimeKind.Utc).AddTicks(1243), "user", null },
                    { new Guid("d7713736-c232-4eb3-82c0-5d20d2483409"), new DateTime(2023, 9, 29, 14, 52, 47, 696, DateTimeKind.Utc).AddTicks(1244), "admin", null }
                });
        }
    }
}
