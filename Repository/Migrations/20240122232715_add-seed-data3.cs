using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8315));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8243));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8244));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8250));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8481), new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8480), new DateTimeOffset(new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Unspecified).AddTicks(8486), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8520), new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8520), new DateTimeOffset(new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Unspecified).AddTicks(8521), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8520) });

            migrationBuilder.InsertData(
                table: "UserImage",
                columns: new[] { "Id", "BlobName", "ContainerName", "CreatedDate", "Extention", "IsActive", "IsRemoved", "RemovedDate", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "1.jpg", "user-image", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8386), "jpg", true, false, null, null, 1 },
                    { 2, "2.jpg", "user-image", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8388), "jpg", true, false, null, null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8418));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 0, 40, 53, 718, DateTimeKind.Local).AddTicks(3167));
        }
    }
}
