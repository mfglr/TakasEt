using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeNameOfBlockingTableToBlockings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockerId",
                table: "Blocking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blocking",
                table: "Blocking");

            migrationBuilder.RenameTable(
                name: "Blocking",
                newName: "Blockings");

            migrationBuilder.RenameIndex(
                name: "IX_Blocking_BlockerId",
                table: "Blockings",
                newName: "IX_Blockings_BlockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blocking_BlockedId",
                table: "Blockings",
                newName: "IX_Blockings_BlockedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blockings",
                table: "Blockings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blockings_AspNetUsers_BlockedId",
                table: "Blockings",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blockings_AspNetUsers_BlockerId",
                table: "Blockings",
                column: "BlockerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blockings_AspNetUsers_BlockedId",
                table: "Blockings");

            migrationBuilder.DropForeignKey(
                name: "FK_Blockings_AspNetUsers_BlockerId",
                table: "Blockings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blockings",
                table: "Blockings");

            migrationBuilder.RenameTable(
                name: "Blockings",
                newName: "Blocking");

            migrationBuilder.RenameIndex(
                name: "IX_Blockings_BlockerId",
                table: "Blocking",
                newName: "IX_Blocking_BlockerId");

            migrationBuilder.RenameIndex(
                name: "IX_Blockings_BlockedId",
                table: "Blocking",
                newName: "IX_Blocking_BlockedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blocking",
                table: "Blocking",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockerId",
                table: "Blocking",
                column: "BlockerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
