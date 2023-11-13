using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Category",
                newName: "NormalizedName");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "Name", "NormalizedName", "UpdatedDate" },
                values: new object[] { new Guid("e17dac4e-3930-457e-858b-96de54391aec"), new DateTime(2023, 11, 12, 22, 19, 28, 591, DateTimeKind.Local).AddTicks(2471), "Kitaplar", "KITAPLAR", null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e17dac4e-3930-457e-858b-96de54391aec"));

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "Category",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 18, 27, 5, 551, DateTimeKind.Utc).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 18, 27, 5, 551, DateTimeKind.Utc).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 12, 18, 27, 5, 551, DateTimeKind.Utc).AddTicks(1869));
        }
    }
}
