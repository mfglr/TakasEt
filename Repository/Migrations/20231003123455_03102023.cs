using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _03102023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
