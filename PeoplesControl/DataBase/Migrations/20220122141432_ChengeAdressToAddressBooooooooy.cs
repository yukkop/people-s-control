using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ChengeAdressToAddressBooooooooy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAdress",
                table: "UsersProfiles");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "UsersProfiles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 22, 17, 14, 31, 672, DateTimeKind.Local).AddTicks(4453));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "UsersProfiles");

            migrationBuilder.AddColumn<string>(
                name: "EmailAdress",
                table: "UsersProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 22, 0, 23, 3, 444, DateTimeKind.Local).AddTicks(9140));
        }
    }
}
