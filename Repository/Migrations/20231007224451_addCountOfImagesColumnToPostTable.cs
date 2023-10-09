using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addCountOfImagesColumnToPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfImages",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 22, 44, 51, 832, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 22, 44, 51, 832, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 22, 44, 51, 832, DateTimeKind.Utc).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 22, 44, 51, 833, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 22, 44, 51, 833, DateTimeKind.Utc).AddTicks(5774));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfImages",
                table: "Posts");

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
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 4, 12, 38, 53, 672, DateTimeKind.Utc).AddTicks(7070));
        }
    }
}
