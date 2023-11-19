using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class refactorPostImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3877));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 19, 19, 22, 33, 186, DateTimeKind.Local).AddTicks(3945));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9606));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9664));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 11, 18, 1, 56, 11, 206, DateTimeKind.Local).AddTicks(9665));
        }
    }
}
