using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRowVersionToConversationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastDisplayedMessage1",
                table: "Conversations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfLastDisplayedMessage2",
                table: "Conversations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Conversations",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfLastDisplayedMessage1",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "DateOfLastDisplayedMessage2",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Conversations");
        }
    }
}
