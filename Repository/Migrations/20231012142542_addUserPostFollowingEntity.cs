using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addUserPostFollowingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPostFollowing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostFollowing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPostFollowing_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPostFollowing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserPostFollowing_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4dec4e47-9808-4fea-b6e9-a54b2da571cf"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 14, 25, 42, 27, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dbcc1a1-2350-4f95-a7a1-3802818843fe"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 14, 25, 42, 27, DateTimeKind.Utc).AddTicks(1154));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a1adfeff-b017-4825-a595-1a691fef079a"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 14, 25, 42, 27, DateTimeKind.Utc).AddTicks(1159));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("136cf280-b2d8-4cfe-8245-08dbc4c7a733"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 14, 25, 42, 27, DateTimeKind.Utc).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("0064a172-4d58-4bdf-a2e7-a9c07928bcc9"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 12, 14, 25, 42, 27, DateTimeKind.Utc).AddTicks(1232));

            migrationBuilder.CreateIndex(
                name: "IX_UserPostFollowing_PostId",
                table: "UserPostFollowing",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostFollowing_UserId",
                table: "UserPostFollowing",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostFollowing_UserId1",
                table: "UserPostFollowing",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPostFollowing");

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
        }
    }
}
