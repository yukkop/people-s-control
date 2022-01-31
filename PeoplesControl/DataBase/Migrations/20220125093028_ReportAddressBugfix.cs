using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ReportAddressBugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reports",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 12, 30, 27, 671, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 12, 30, 27, 672, DateTimeKind.Local).AddTicks(4778));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Reports",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 18, 23, 19, 590, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 18, 23, 19, 591, DateTimeKind.Local).AddTicks(4819));
        }
    }
}
