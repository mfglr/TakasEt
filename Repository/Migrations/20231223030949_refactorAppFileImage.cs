using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorAppFileImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_Post_PostId",
                table: "AppFile");

            migrationBuilder.DropForeignKey(
                name: "FK_AppFile_User_UserId",
                table: "AppFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppFile",
                table: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_AppFile_UserId",
                table: "AppFile");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppFile");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppFile");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppFile");

            migrationBuilder.RenameTable(
                name: "AppFile",
                newName: "PostImage");

            migrationBuilder.RenameIndex(
                name: "IX_AppFile_PostId",
                table: "PostImage",
                newName: "IX_PostImage_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "PostImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "PostImage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 23, 6, 9, 48, 378, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_UserId",
                table: "UserImage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImage_Post_PostId",
                table: "PostImage",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostImage_Post_PostId",
                table: "PostImage");

            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostImage",
                table: "PostImage");

            migrationBuilder.RenameTable(
                name: "PostImage",
                newName: "AppFile");

            migrationBuilder.RenameIndex(
                name: "IX_PostImage_PostId",
                table: "AppFile",
                newName: "IX_AppFile_PostId");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "AppFile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "AppFile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppFile",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AppFile",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppFile",
                table: "AppFile",
                column: "Id");

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
                name: "IX_AppFile_UserId",
                table: "AppFile",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_Post_PostId",
                table: "AppFile",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFile_User_UserId",
                table: "AppFile",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
