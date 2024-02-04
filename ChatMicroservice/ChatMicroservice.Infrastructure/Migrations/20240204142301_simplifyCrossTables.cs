using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class simplifyCrossTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUserRemoving_Conversations_ConversationId",
                table: "ConversationUserRemoving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserLiking_Messages_MessageId",
                table: "MessageUserLiking");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserReceiving_Messages_MessageId",
                table: "MessageUserReceiving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserRemoving_Messages_MessageId",
                table: "MessageUserRemoving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserViewing_Messages_MessageId",
                table: "MessageUserViewing");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserViewing",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserRemoving",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserReceiving",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserLiking",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConversationId",
                table: "ConversationUserRemoving",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUserRemoving_Conversations_ConversationId",
                table: "ConversationUserRemoving",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserLiking_Messages_MessageId",
                table: "MessageUserLiking",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserReceiving_Messages_MessageId",
                table: "MessageUserReceiving",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserRemoving_Messages_MessageId",
                table: "MessageUserRemoving",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserViewing_Messages_MessageId",
                table: "MessageUserViewing",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationUserRemoving_Conversations_ConversationId",
                table: "ConversationUserRemoving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserLiking_Messages_MessageId",
                table: "MessageUserLiking");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserReceiving_Messages_MessageId",
                table: "MessageUserReceiving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserRemoving_Messages_MessageId",
                table: "MessageUserRemoving");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageUserViewing_Messages_MessageId",
                table: "MessageUserViewing");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserViewing",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserRemoving",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserReceiving",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "MessageUserLiking",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ConversationId",
                table: "ConversationUserRemoving",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationUserRemoving_Conversations_ConversationId",
                table: "ConversationUserRemoving",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserLiking_Messages_MessageId",
                table: "MessageUserLiking",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserReceiving_Messages_MessageId",
                table: "MessageUserReceiving",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserRemoving_Messages_MessageId",
                table: "MessageUserRemoving",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageUserViewing_Messages_MessageId",
                table: "MessageUserViewing",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
