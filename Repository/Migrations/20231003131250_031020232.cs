using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _031020232 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("64e5a80d-cf99-4f04-ba7f-44aed243c885"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5058), "client", null },
                    { new Guid("a3abc9c0-f483-4069-9f39-e2d1a8de6739"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5061), "user", null },
                    { new Guid("fdd8270a-167d-4a06-b7f8-0b0dfffcfab4"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5071), "admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("64e5a80d-cf99-4f04-ba7f-44aed243c885"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a3abc9c0-f483-4069-9f39-e2d1a8de6739"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fdd8270a-167d-4a06-b7f8-0b0dfffcfab4"));

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
    }
}
