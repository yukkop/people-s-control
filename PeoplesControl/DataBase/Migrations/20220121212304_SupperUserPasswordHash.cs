using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class SupperUserPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SMSConfirmationCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmailConfirmationCode",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSMSConfirmation",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEmailConfirmation",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 22, 0, 23, 3, 444, DateTimeKind.Local).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateEmailConfirmation", "DateSMSConfirmation", "EmailConfirmationCode", "SMSConfirmationCode", "SaltPassword", "SaltValue" },
                values: new object[] { null, null, null, null, new byte[] { 179, 116, 232, 248, 45, 66, 50, 216, 71, 167, 174, 126, 161, 156, 7, 15, 1, 180, 238, 187, 20, 54, 156, 229, 208, 213, 38, 9, 101, 129, 20, 29 }, new byte[] { 242, 3, 62, 221, 169, 59, 244, 197, 207, 234, 53, 50, 77, 20, 139, 149, 229, 94, 234, 17, 19, 5, 169, 55, 184, 124, 139, 169, 205, 6, 47, 224 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SMSConfirmationCode",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmailConfirmationCode",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSMSConfirmation",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEmailConfirmation",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 21, 23, 20, 6, 830, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateEmailConfirmation", "DateSMSConfirmation", "EmailConfirmationCode", "SMSConfirmationCode", "SaltPassword", "SaltValue" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, new byte[] {  }, new byte[] {  } });
        }
    }
}
