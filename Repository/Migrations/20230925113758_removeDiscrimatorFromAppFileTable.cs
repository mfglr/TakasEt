using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeDiscrimatorFromAppFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("161bcef8-96bf-4548-879b-8e545fc76afb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("19da35b9-82f0-4d56-b8cf-88efc7806bf1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c5038766-b8df-48e1-a769-5c19dbe291c2"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppFiles");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("78e6daab-6d9e-4473-a3a3-e08a241c4621"), new DateTime(2023, 9, 25, 11, 37, 58, 534, DateTimeKind.Utc).AddTicks(6240), "client", null },
                    { new Guid("d2a29620-2f53-450d-b384-013eb297e87b"), new DateTime(2023, 9, 25, 11, 37, 58, 534, DateTimeKind.Utc).AddTicks(6245), "admin", null },
                    { new Guid("e3e0e00e-05cd-4139-9302-aa1f2a4a291b"), new DateTime(2023, 9, 25, 11, 37, 58, 534, DateTimeKind.Utc).AddTicks(6244), "user", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("78e6daab-6d9e-4473-a3a3-e08a241c4621"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d2a29620-2f53-450d-b384-013eb297e87b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e3e0e00e-05cd-4139-9302-aa1f2a4a291b"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("161bcef8-96bf-4548-879b-8e545fc76afb"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3718), "client", null },
                    { new Guid("19da35b9-82f0-4d56-b8cf-88efc7806bf1"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3722), "admin", null },
                    { new Guid("c5038766-b8df-48e1-a769-5c19dbe291c2"), new DateTime(2023, 9, 20, 12, 24, 2, 269, DateTimeKind.Utc).AddTicks(3721), "user", null }
                });
        }
    }
}
