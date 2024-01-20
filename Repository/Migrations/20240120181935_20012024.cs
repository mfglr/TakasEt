using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _20012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swapping_Post_DestinationPostId",
                table: "Swapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserFollowing_User_FollowedId",
                table: "UserUserFollowing");

            migrationBuilder.DropTable(
                name: "PostPostRequesting");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Swapping_DestinationPostId",
                table: "Swapping");

            migrationBuilder.DropColumn(
                name: "SwappingId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "FollowedId",
                table: "UserUserFollowing",
                newName: "FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUserFollowing_FollowedId",
                table: "UserUserFollowing",
                newName: "IX_UserUserFollowing_FollowingId");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Swapping",
                newName: "RequesterId");

            migrationBuilder.RenameColumn(
                name: "DestinationPostId",
                table: "Swapping",
                newName: "RequestedId");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Swapping",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Requesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    RequestedId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requesting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requesting_Post_RequestedId",
                        column: x => x.RequestedId,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requesting_Post_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9814));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9815));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9816));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9817));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9818));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 21, 19, 35, 426, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.CreateIndex(
                name: "IX_Swapping_RequestedId",
                table: "Swapping",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_Swapping_RequesterId",
                table: "Swapping",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Requesting_RequestedId",
                table: "Requesting",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_Requesting_RequesterId",
                table: "Requesting",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swapping_Post_RequestedId",
                table: "Swapping",
                column: "RequestedId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Swapping_Post_RequesterId",
                table: "Swapping",
                column: "RequesterId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserFollowing_User_FollowingId",
                table: "UserUserFollowing",
                column: "FollowingId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swapping_Post_RequestedId",
                table: "Swapping");

            migrationBuilder.DropForeignKey(
                name: "FK_Swapping_Post_RequesterId",
                table: "Swapping");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserFollowing_User_FollowingId",
                table: "UserUserFollowing");

            migrationBuilder.DropTable(
                name: "Requesting");

            migrationBuilder.DropIndex(
                name: "IX_Swapping_RequestedId",
                table: "Swapping");

            migrationBuilder.DropIndex(
                name: "IX_Swapping_RequesterId",
                table: "Swapping");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Swapping");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "UserUserFollowing",
                newName: "FollowedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUserFollowing_FollowingId",
                table: "UserUserFollowing",
                newName: "IX_UserUserFollowing_FollowedId");

            migrationBuilder.RenameColumn(
                name: "RequesterId",
                table: "Swapping",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "RequestedId",
                table: "Swapping",
                newName: "DestinationPostId");

            migrationBuilder.AddColumn<int>(
                name: "SwappingId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostPostRequesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedId = table.Column<int>(type: "int", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6002));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 16, 13, 50, 36, 326, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.CreateIndex(
                name: "IX_Swapping_DestinationPostId",
                table: "Swapping",
                column: "DestinationPostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostPostRequesting_RequestedId",
                table: "PostPostRequesting",
                column: "RequestedId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostRequesting_RequesterId",
                table: "PostPostRequesting",
                column: "RequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swapping_Post_DestinationPostId",
                table: "Swapping",
                column: "DestinationPostId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserFollowing_User_FollowedId",
                table: "UserUserFollowing",
                column: "FollowedId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
