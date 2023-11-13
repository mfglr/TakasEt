using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Post",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedTitle",
                table: "Post",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e17dac4e-3930-457e-858b-96de54391aec"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 22, 38, 5, 560, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 38, 5, 560, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 38, 5, 560, DateTimeKind.Utc).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 38, 5, 560, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.CreateIndex(
                name: "titleIndexer",
                table: "Post",
                column: "NormalizedTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "titleIndexer",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "NormalizedTitle",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e17dac4e-3930-457e-858b-96de54391aec"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 22, 19, 28, 591, DateTimeKind.Local).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 19, 28, 591, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 19, 28, 591, DateTimeKind.Utc).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 19, 19, 28, 591, DateTimeKind.Utc).AddTicks(2591));
        }
    }
}
