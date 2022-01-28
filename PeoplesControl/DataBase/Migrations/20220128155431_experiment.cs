using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class experiment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 54, 30, 792, DateTimeKind.Local).AddTicks(8587));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 54, 30, 793, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 54, 30, 793, DateTimeKind.Local).AddTicks(8818));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 50, 4, 52, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 50, 4, 53, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 18, 50, 4, 53, DateTimeKind.Local).AddTicks(2536));
        }
    }
}
