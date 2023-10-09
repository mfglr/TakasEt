using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class makeIdsOfRoleEntitiesConst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("444cbc6f-c577-4b08-bfe9-f86896ab68b3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6050b4cd-e029-4eab-ab53-9a5da551b3d4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a75becd7-1ec9-493f-9663-1729b39917cc"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"), new DateTime(2023, 10, 4, 10, 48, 0, 687, DateTimeKind.Utc).AddTicks(1872), "user", null },
                    { new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"), new DateTime(2023, 10, 4, 10, 48, 0, 687, DateTimeKind.Utc).AddTicks(1868), "client", null },
                    { new Guid("a1adfeff-b017-4825-a595-1a691fef079a"), new DateTime(2023, 10, 4, 10, 48, 0, 687, DateTimeKind.Utc).AddTicks(1873), "admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("444cbc6f-c577-4b08-bfe9-f86896ab68b3"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(480), "admin", null },
                    { new Guid("6050b4cd-e029-4eab-ab53-9a5da551b3d4"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(479), "user", null },
                    { new Guid("a75becd7-1ec9-493f-9663-1729b39917cc"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(474), "client", null }
                });
        }
    }
}
