using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ImplimentRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 12, 41, 25, 924, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 12, 41, 25, 925, DateTimeKind.Local).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Guest");

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 23, 14, 0, 21, 591, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 23, 14, 0, 21, 592, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Админ");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Гость");
        }
    }
}
