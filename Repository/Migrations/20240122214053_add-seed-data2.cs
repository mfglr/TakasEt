using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2890));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2905));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3205), new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3204), new DateTimeOffset(new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Unspecified).AddTicks(3208), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3205) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3245), new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3245), new DateTimeOffset(new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId", "CreatedDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3165), null },
                    { 2, 2, new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3167), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8128));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8052));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8055));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8218), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8217), new DateTimeOffset(new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Unspecified).AddTicks(8222), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8218) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8257), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8257), new DateTimeOffset(new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 0, 34, 2, 213, DateTimeKind.Local).AddTicks(8258) });
        }
    }
}
