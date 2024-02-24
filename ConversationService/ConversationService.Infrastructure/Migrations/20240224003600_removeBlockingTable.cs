using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeBlockingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocking_UserConnections_BlockedId",
                        column: x => x.BlockedId,
                        principalTable: "UserConnections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blocking_UserConnections_BlockerId",
                        column: x => x.BlockerId,
                        principalTable: "UserConnections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockedId",
                table: "Blocking",
                column: "BlockedId");

            migrationBuilder.CreateIndex(
                name: "IX_Blocking_BlockerId",
                table: "Blocking",
                column: "BlockerId");
        }
    }
}
