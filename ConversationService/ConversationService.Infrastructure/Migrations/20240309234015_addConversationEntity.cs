using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addConversationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConversationUserId1",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConversationUserId2",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => new { x.UserId1, x.UserId2 });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationUserId1_ConversationUserId2",
                table: "Messages",
                columns: new[] { "ConversationUserId1", "ConversationUserId2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Conversations_ConversationUserId1_ConversationUserId2",
                table: "Messages",
                columns: new[] { "ConversationUserId1", "ConversationUserId2" },
                principalTable: "Conversations",
                principalColumns: new[] { "UserId1", "UserId2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Conversations_ConversationUserId1_ConversationUserId2",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ConversationUserId1_ConversationUserId2",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ConversationUserId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ConversationUserId2",
                table: "Messages");
        }
    }
}
