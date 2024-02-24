﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocking_AspNetUsers_BlockedId",
                table: "Blocking",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
