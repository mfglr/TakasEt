using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUserConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivateConnection",
                table: "Connections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Blocking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocking_Connections_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blocking_Connections_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Communication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communication_Connections_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communication_Connections_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Connections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ReceiverId",
                table: "Conversations",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_SenderId",
                table: "Conversations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockedId",
                table: "Blocking",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockerId",
                table: "Blocking",
                column: "BlockerId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_ReceiverId",
                table: "Communication",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_SenderId",
                table: "Communication",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Connections_ReceiverId",
                table: "Conversations",
                column: "ReceiverId",
                principalTable: "Connections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Connections_SenderId",
                table: "Conversations",
                column: "SenderId",
                principalTable: "Connections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Connections_ReceiverId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Connections_SenderId",
                table: "Conversations");

            migrationBuilder.DropTable(
                name: "Blocking");

            migrationBuilder.DropTable(
                name: "Communication");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_ReceiverId",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_SenderId",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "IsPrivateConnection",
                table: "Connections");
        }
    }
}
