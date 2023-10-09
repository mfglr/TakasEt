using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class changeNameSwapRequestToPosPostRequesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwapRequest");

            migrationBuilder.CreateTable(
                name: "PostPostRequesting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPostRequesting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPostRequesting_Post_RequestedId",
                        column: x => x.RequestedId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostPostRequesting_Post_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 50, 1, 710, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 50, 1, 710, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 50, 1, 710, DateTimeKind.Utc).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 50, 1, 710, DateTimeKind.Utc).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 50, 1, 710, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.CreateIndex(
                name: "IX_PostPostRequesting_RequestedId",
                table: "PostPostRequesting",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostRequesting_RequesterId",
                table: "PostPostRequesting",
                column: "RequesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPostRequesting");

            migrationBuilder.CreateTable(
                name: "SwapRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwapRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwapRequest_Post_RequestedId",
                        column: x => x.RequestedId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SwapRequest_Post_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 42, 49, 523, DateTimeKind.Utc).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 42, 49, 523, DateTimeKind.Utc).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 42, 49, 523, DateTimeKind.Utc).AddTicks(382));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 42, 49, 523, DateTimeKind.Utc).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 9, 21, 42, 49, 523, DateTimeKind.Utc).AddTicks(434));

            migrationBuilder.CreateIndex(
                name: "IX_SwapRequest_RequestedId",
                table: "SwapRequest",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_SwapRequest_RequesterId",
                table: "SwapRequest",
                column: "RequesterId");
        }
    }
}
