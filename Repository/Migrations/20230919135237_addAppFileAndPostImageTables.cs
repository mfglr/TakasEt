using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addAppFileAndPostImageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0db5cc7e-59c9-48d4-99d9-05b1c64886f9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5684a7cd-99f8-490d-8296-8a9a0abb34b5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2408e0d-9791-42f0-b71c-65c0d0b52529"));

            migrationBuilder.DropColumn(
                name: "BlobNameOfFile",
                table: "ProfilePicture");

            migrationBuilder.DropColumn(
                name: "ContainerNameOfFile",
                table: "ProfilePicture");

            migrationBuilder.AddColumn<Guid>(
                name: "AppFileId",
                table: "ProfilePicture",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "AppFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFile_PostImage_PostImageId",
                        column: x => x.PostImageId,
                        principalTable: "PostImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppFile_ProfilePicture_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "ProfilePicture",
                        principalColumn: "Id");
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFile");

            migrationBuilder.DropTable(
                name: "PostImage");

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

            migrationBuilder.DropColumn(
                name: "AppFileId",
                table: "ProfilePicture");

            migrationBuilder.AddColumn<string>(
                name: "BlobNameOfFile",
                table: "ProfilePicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContainerNameOfFile",
                table: "ProfilePicture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0db5cc7e-59c9-48d4-99d9-05b1c64886f9"), new DateTime(2023, 9, 18, 12, 19, 47, 976, DateTimeKind.Utc).AddTicks(5197), "user", null },
                    { new Guid("5684a7cd-99f8-490d-8296-8a9a0abb34b5"), new DateTime(2023, 9, 18, 12, 19, 47, 976, DateTimeKind.Utc).AddTicks(5208), "admin", null },
                    { new Guid("b2408e0d-9791-42f0-b71c-65c0d0b52529"), new DateTime(2023, 9, 18, 12, 19, 47, 976, DateTimeKind.Utc).AddTicks(5195), "client", null }
                });
        }
    }
}
