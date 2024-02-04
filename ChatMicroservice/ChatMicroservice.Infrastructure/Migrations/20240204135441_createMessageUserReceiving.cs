using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createMessageUserReceiving : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "GroupUser",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "MessageUserReceiving",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageUserReceiving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageUserReceiving_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageUserReceiving_MessageId",
                table: "MessageUserReceiving",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser");

            migrationBuilder.DropTable(
                name: "MessageUserReceiving");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "GroupUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUser_Groups_GroupId",
                table: "GroupUser",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
