using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class UsersAddUniqueFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 17, 55, 58, 407, DateTimeKind.Local).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 17, 55, 58, 408, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 17, 55, 58, 408, DateTimeKind.Local).AddTicks(1685));

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_EmailAddress",
                table: "UsersProfiles",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_PhoneNumber",
                table: "UsersProfiles",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_EmailAddress",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_PhoneNumber",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 14, 4, 21, 713, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 14, 4, 21, 715, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Date",
                value: new DateTime(2022, 1, 28, 14, 4, 21, 715, DateTimeKind.Local).AddTicks(6040));
        }
    }
}
