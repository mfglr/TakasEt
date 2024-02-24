using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeNameOfConnectionToUserConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_Connections_BlockedId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_Connections_BlockerId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Communication_Connections_ReceiverId",
                table: "Communication");

            migrationBuilder.DropForeignKey(
                name: "FK_Communication_Connections_SenderId",
                table: "Communication");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Connections_ReceiverId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Connections_SenderId",
                table: "Conversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Connections",
                table: "Connections");

            migrationBuilder.RenameTable(
                name: "Connections",
                newName: "UserConnections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConnections",
                table: "UserConnections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_UserConnections_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "UserConnections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_UserConnections_BlockerId",
                table: "Blocking",
                column: "BlockerId",
                principalTable: "UserConnections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_UserConnections_ReceiverId",
                table: "Communication",
                column: "ReceiverId",
                principalTable: "UserConnections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_UserConnections_SenderId",
                table: "Communication",
                column: "SenderId",
                principalTable: "UserConnections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_UserConnections_ReceiverId",
                table: "Conversations",
                column: "ReceiverId",
                principalTable: "UserConnections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_UserConnections_SenderId",
                table: "Conversations",
                column: "SenderId",
                principalTable: "UserConnections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_UserConnections_BlockedId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_UserConnections_BlockerId",
                table: "Blocking");

            migrationBuilder.DropForeignKey(
                name: "FK_Communication_UserConnections_ReceiverId",
                table: "Communication");

            migrationBuilder.DropForeignKey(
                name: "FK_Communication_UserConnections_SenderId",
                table: "Communication");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_UserConnections_ReceiverId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_UserConnections_SenderId",
                table: "Conversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConnections",
                table: "UserConnections");

            migrationBuilder.RenameTable(
                name: "UserConnections",
                newName: "Connections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Connections",
                table: "Connections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_Connections_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "Connections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_Connections_BlockerId",
                table: "Blocking",
                column: "BlockerId",
                principalTable: "Connections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_Connections_ReceiverId",
                table: "Communication",
                column: "ReceiverId",
                principalTable: "Connections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Communication_Connections_SenderId",
                table: "Communication",
                column: "SenderId",
                principalTable: "Connections",
                principalColumn: "Id");

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
    }
}
