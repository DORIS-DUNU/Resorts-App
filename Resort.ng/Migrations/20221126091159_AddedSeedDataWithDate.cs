using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resort.ng.Migrations
{
    public partial class AddedSeedDataWithDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 26, 10, 11, 59, 491, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 26, 10, 11, 59, 491, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 26, 10, 11, 59, 491, DateTimeKind.Local).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 26, 10, 11, 59, 491, DateTimeKind.Local).AddTicks(3990));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Resorts_Db",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
