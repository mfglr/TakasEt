using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdOfUserApprovingOrCancellingRequestColumnToGroupUserRequestToJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdOfUserApprovingOrCancellingRequest",
                table: "GroupUserRequestToJoin",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfUserApprovingOrCancellingRequest",
                table: "GroupUserRequestToJoin");
        }
    }
}
