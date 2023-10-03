using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _031020231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("24392449-8320-440b-a13b-72f891b3c0c8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e13537ca-13c5-4b0b-a67c-5c137850c79a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f73874f9-0e2e-4ddc-8da4-bde6524d5167"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppFiles",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("36b450f6-ae69-44fd-a42c-a36fe124cd3f"), new DateTime(2023, 10, 3, 13, 7, 11, 749, DateTimeKind.Utc).AddTicks(9076), "user", null },
                    { new Guid("3af8f74c-b83e-41e2-a122-0affc3c77dba"), new DateTime(2023, 10, 3, 13, 7, 11, 749, DateTimeKind.Utc).AddTicks(9084), "admin", null },
                    { new Guid("c40bed21-6ac2-4dc7-8421-5352cc5aecde"), new DateTime(2023, 10, 3, 13, 7, 11, 749, DateTimeKind.Utc).AddTicks(9071), "client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("36b450f6-ae69-44fd-a42c-a36fe124cd3f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3af8f74c-b83e-41e2-a122-0affc3c77dba"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c40bed21-6ac2-4dc7-8421-5352cc5aecde"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppFiles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppFiles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("24392449-8320-440b-a13b-72f891b3c0c8"), new DateTime(2023, 10, 3, 12, 34, 55, 16, DateTimeKind.Utc).AddTicks(7987), "admin", null },
                    { new Guid("e13537ca-13c5-4b0b-a67c-5c137850c79a"), new DateTime(2023, 10, 3, 12, 34, 55, 16, DateTimeKind.Utc).AddTicks(7986), "user", null },
                    { new Guid("f73874f9-0e2e-4ddc-8da4-bde6524d5167"), new DateTime(2023, 10, 3, 12, 34, 55, 16, DateTimeKind.Utc).AddTicks(7983), "client", null }
                });
        }
    }
}
