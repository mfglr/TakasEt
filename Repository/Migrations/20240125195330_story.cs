using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class story : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Story_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoryImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    DisplayTime = table.Column<int>(type: "int", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    AspectRatio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryImage_Story_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Story",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserStoryImageLiking",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryImageLiking", x => new { x.UserId, x.StoryImageId });
                    table.ForeignKey(
                        name: "FK_UserStoryImageLiking_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserStoryImageLiking_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserStoryImageViewing",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StoryImageId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStoryImageViewing", x => new { x.UserId, x.StoryImageId });
                    table.ForeignKey(
                        name: "FK_UserStoryImageViewing_StoryImage_StoryImageId",
                        column: x => x.StoryImageId,
                        principalTable: "StoryImage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserStoryImageViewing_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Story_UserId",
                table: "Story",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryImage_StoryId",
                table: "StoryImage",
                column: "StoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryImageLiking_StoryImageId",
                table: "UserStoryImageLiking",
                column: "StoryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStoryImageViewing_StoryImageId",
                table: "UserStoryImageViewing",
                column: "StoryImageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStoryImageLiking");

            migrationBuilder.DropTable(
                name: "UserStoryImageViewing");

            migrationBuilder.DropTable(
                name: "StoryImage");

            migrationBuilder.DropTable(
                name: "Story");
        }
    }
}
