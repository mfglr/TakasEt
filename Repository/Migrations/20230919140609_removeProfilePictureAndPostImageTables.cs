using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeProfilePictureAndPostImageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_PostImage_PostImageId",
                table: "AppFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_ProfilePicture_ProfilePictureId",
                table: "AppFile");

            migrationBuilder.DropTable(
                name: "PostImage");

            migrationBuilder.DropTable(
                name: "ProfilePicture");

            migrationBuilder.DropIndex(
                name: "IX_AppFile_PostImageId",
                table: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_AppFile_ProfilePictureId",
                table: "AppFile");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1285e4f9-fbda-499c-b0ed-77374be6b14d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("872d2343-d949-4fdb-b909-f341e0d854c6"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fd50c9a7-affb-4905-973f-b2932cf1df8b"));

            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "AppFile",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PostImageId",
                table: "AppFile",
                newName: "PostId");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6a50d04e-26e4-4182-9a26-0a1e73fe2eeb"), new DateTime(2023, 9, 19, 14, 6, 9, 203, DateTimeKind.Utc).AddTicks(9243), "admin", null },
                    { new Guid("755301e9-15d9-4445-8c28-f9b2f0e7aa6f"), new DateTime(2023, 9, 19, 14, 6, 9, 203, DateTimeKind.Utc).AddTicks(9237), "client", null },
                    { new Guid("8c732a36-3905-4fb3-93b9-b7a25fc61e17"), new DateTime(2023, 9, 19, 14, 6, 9, 203, DateTimeKind.Utc).AddTicks(9241), "user", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFile_PostId",
                table: "AppFile",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFile_UserId",
                table: "AppFile",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_Posts_PostId",
                table: "AppFile",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_Users_UserId",
                table: "AppFile",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_Posts_PostId",
                table: "AppFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_Users_UserId",
                table: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_AppFile_PostId",
                table: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_AppFile_UserId",
                table: "AppFile");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6a50d04e-26e4-4182-9a26-0a1e73fe2eeb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("755301e9-15d9-4445-8c28-f9b2f0e7aa6f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8c732a36-3905-4fb3-93b9-b7a25fc61e17"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppFile",
                newName: "ProfilePictureId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "AppFile",
                newName: "PostImageId");

            migrationBuilder.CreateTable(
                name: "PostImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImage_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDisplayed = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePicture_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1285e4f9-fbda-499c-b0ed-77374be6b14d"), new DateTime(2023, 9, 19, 13, 52, 37, 726, DateTimeKind.Utc).AddTicks(6926), "user", null },
                    { new Guid("872d2343-d949-4fdb-b909-f341e0d854c6"), new DateTime(2023, 9, 19, 13, 52, 37, 726, DateTimeKind.Utc).AddTicks(6927), "admin", null },
                    { new Guid("fd50c9a7-affb-4905-973f-b2932cf1df8b"), new DateTime(2023, 9, 19, 13, 52, 37, 726, DateTimeKind.Utc).AddTicks(6914), "client", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFile_PostImageId",
                table: "AppFile",
                column: "PostImageId",
                unique: true,
                filter: "[PostImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppFile_ProfilePictureId",
                table: "AppFile",
                column: "ProfilePictureId",
                unique: true,
                filter: "[ProfilePictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PostImage_PostId",
                table: "PostImage",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePicture_UserId",
                table: "ProfilePicture",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_PostImage_PostImageId",
                table: "AppFile",
                column: "PostImageId",
                principalTable: "PostImage",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_ProfilePicture_ProfilePictureId",
                table: "AppFile",
                column: "ProfilePictureId",
                principalTable: "ProfilePicture",
                principalColumn: "Id");
        }
    }
}
