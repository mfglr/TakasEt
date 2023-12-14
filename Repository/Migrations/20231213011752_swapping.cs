using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class swapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "createdDateIndexer",
                table: "User");

            migrationBuilder.DropIndex(
                name: "createdDateIndexer",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "SwappingId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Swapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationPostId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swapping_Post_DestinationPostId",
                        column: x => x.DestinationPostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SwappingCommentContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwappingCommentContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwappingComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SwappingCommentContentId = table.Column<int>(type: "int", nullable: false),
                    SwappingId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwappingComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwappingComment_SwappingCommentContent_SwappingCommentContentId",
                        column: x => x.SwappingCommentContentId,
                        principalTable: "SwappingCommentContent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SwappingComment_Swapping_SwappingId",
                        column: x => x.SwappingId,
                        principalTable: "Swapping",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 13, 4, 17, 52, 216, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.CreateIndex(
                name: "IX_Swapping_DestinationPostId",
                table: "Swapping",
                column: "DestinationPostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwappingComment_SwappingCommentContentId",
                table: "SwappingComment",
                column: "SwappingCommentContentId");

            migrationBuilder.CreateIndex(
                name: "IX_SwappingComment_SwappingId",
                table: "SwappingComment",
                column: "SwappingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwappingComment");

            migrationBuilder.DropTable(
                name: "SwappingCommentContent");

            migrationBuilder.DropTable(
                name: "Swapping");

            migrationBuilder.DropColumn(
                name: "SwappingId",
                table: "Post");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1599));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 9, 16, 18, 9, 606, DateTimeKind.Local).AddTicks(1667));

            migrationBuilder.CreateIndex(
                name: "createdDateIndexer",
                table: "User",
                column: "CreatedDate",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "createdDateIndexer",
                table: "Post",
                column: "CreatedDate",
                descending: new bool[0]);
        }
    }
}
