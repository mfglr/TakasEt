using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addColumnNamedAsAspectRatioToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AspectRatio",
                table: "UserImage",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AspectRatio",
                table: "PostImage",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "AspectRatio",
                table: "ConversationImage",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AspectRatio",
                table: "UserImage");

            migrationBuilder.DropColumn(
                name: "AspectRatio",
                table: "PostImage");

            migrationBuilder.DropColumn(
                name: "AspectRatio",
                table: "ConversationImage");
        }
    }
}
