using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addSwapRequestedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

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

            migrationBuilder.CreateTable(
                name: "SwapRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapRequest_Posts_RequestedId",
                        column: x => x.RequestedId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SwapRequest_Posts_RequestingId",
                        column: x => x.RequestingId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("444cbc6f-c577-4b08-bfe9-f86896ab68b3"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(480), "admin", null },
                    { new Guid("6050b4cd-e029-4eab-ab53-9a5da551b3d4"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(479), "user", null },
                    { new Guid("a75becd7-1ec9-493f-9663-1729b39917cc"), new DateTime(2023, 10, 4, 9, 35, 53, 440, DateTimeKind.Utc).AddTicks(474), "client", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwapRequest_RequestedId",
                table: "SwapRequest",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapRequest_RequestingId",
                table: "SwapRequest",
                column: "RequestingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "SwapRequest");

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
                    { new Guid("64e5a80d-cf99-4f04-ba7f-44aed243c885"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5058), "client", null },
                    { new Guid("a3abc9c0-f483-4069-9f39-e2d1a8de6739"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5061), "user", null },
                    { new Guid("fdd8270a-167d-4a06-b7f8-0b0dfffcfab4"), new DateTime(2023, 10, 3, 13, 12, 50, 232, DateTimeKind.Utc).AddTicks(5071), "admin", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
