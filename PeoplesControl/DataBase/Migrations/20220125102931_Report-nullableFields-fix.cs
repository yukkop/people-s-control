using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ReportnullableFieldsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports");

            migrationBuilder.AlterColumn<long>(
                name: "RelationReportId",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ModeratorId",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 13, 29, 31, 150, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 13, 29, 31, 151, DateTimeKind.Local).AddTicks(7803));

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports",
                column: "RelationReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports");

            migrationBuilder.AlterColumn<long>(
                name: "RelationReportId",
                table: "Reports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModeratorId",
                table: "Reports",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 12, 35, 31, 397, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 12, 35, 31, 398, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports",
                column: "RelationReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
