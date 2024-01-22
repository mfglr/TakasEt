using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7684));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Following",
                keyColumns: new[] { "FollowerId", "FollowingId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_0.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7831) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_1.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7831) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_2.jpg", new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8031), new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8031), new DateTimeOffset(new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DateOfBirth", "LockoutEnd", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8068), new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8068), new DateTimeOffset(new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Unspecified).AddTicks(8069), new TimeSpan(0, 3, 0, 0, 0)), new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(8068) });

            migrationBuilder.UpdateData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 31, 42, 467, DateTimeKind.Local).AddTicks(7994));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8235) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8238) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "1_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8239) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "2_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8240) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8241) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "3_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8242) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8243) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "4_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8244) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "5_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8249) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8250) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8250) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "6_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "7_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8252) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8254) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "8_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8254) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8255) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "9_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_0", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_1", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8257) });

            migrationBuilder.UpdateData(
                table: "PostImage",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BlobName", "CreatedDate" },
                values: new object[] { "10_2", new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8257) });

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

            migrationBuilder.UpdateData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "UserImage",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 2, 27, 15, 656, DateTimeKind.Local).AddTicks(8388));

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
    }
}
