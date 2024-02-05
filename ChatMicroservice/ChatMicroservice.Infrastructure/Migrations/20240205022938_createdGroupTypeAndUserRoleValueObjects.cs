using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createdGroupTypeAndUserRoleValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "GroupUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "GroupUser");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Groups");
        }
    }
}
