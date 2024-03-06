using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameOf_DateTimeOfLastMessageReceived_ColumnTo_DateTimeOfLastMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeOfLastMessageReceived",
                table: "Conversations",
                newName: "DateTimeOfLastMessage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeOfLastMessage",
                table: "Conversations",
                newName: "DateTimeOfLastMessageReceived");
        }
    }
}
