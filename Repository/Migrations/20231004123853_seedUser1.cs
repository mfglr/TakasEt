using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class seedUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(6070));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                columns: new[] { "CreatedDate", "RoleId" },
                values: new object[] { new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(6988), new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(7070));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDate", "RoleId" },
                values: new object[] { new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6139), new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 23, 31, 118, DateTimeKind.Utc).AddTicks(6184));
        }
    }
}
