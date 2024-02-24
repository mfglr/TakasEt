using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMessageImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_UserConnections_ReceiverId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_UserConnections_SenderId",
                table: "Conversations");

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
                table: "UserConnections");

            migrationBuilder.CreateTable(
                name: "MessageImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContainerName_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dimension_Height = table.Column<int>(type: "int", nullable: false),
                    Dimension_Width = table.Column<int>(type: "int", nullable: false),
                    Dimension_AspectRatio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageImage_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageImage_MessageId",
                table: "MessageImage",
                column: "MessageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageImage");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivateConnection",
                table: "UserConnections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Communication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communication_UserConnections_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "UserConnections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Communication_UserConnections_SenderId",
                        column: x => x.SenderId,
                        principalTable: "UserConnections",
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
                name: "IX_Communication_ReceiverId",
                table: "Communication",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_SenderId",
                table: "Communication",
                column: "SenderId");

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
    }
}
