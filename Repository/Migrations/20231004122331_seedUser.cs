using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6064));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { 0, "605095b2-c70f-4f4d-b85c-b2adde79c0ec", new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6184), true, "THENQLV@OUTLOOK.COM", "THENQLV", "MJ3TWU3F4CA3YUYFWTJMO3GXQUXGWT4F" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 11, 54, 23, 320, DateTimeKind.Utc).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 11, 54, 23, 320, DateTimeKind.Utc).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 11, 54, 23, 320, DateTimeKind.Utc).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 11, 54, 23, 320, DateTimeKind.Utc).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "LockoutEnabled", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { 3, null, new DateTime(2023, 10, 4, 11, 54, 23, 320, DateTimeKind.Utc).AddTicks(3674), false, null, null, null });
        }
    }
}
