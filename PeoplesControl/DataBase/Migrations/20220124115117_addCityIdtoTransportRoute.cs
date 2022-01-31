using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class addCityIdtoTransportRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "TransportRoutes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 14, 51, 16, 843, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 14, 51, 16, 843, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "SaltPassword", "SaltValue" },
                values: new object[] { new byte[] { 133, 17, 106, 142, 11, 55, 24, 255, 120, 66, 77, 48, 20, 232, 1, 81, 30, 78, 164, 83, 42, 224, 147, 224, 37, 147, 105, 53, 170, 172, 249, 108 }, new byte[] { 97, 234, 60, 207, 110, 168, 164, 13, 64, 190, 70, 8, 4, 203, 74, 107, 187, 80, 160, 123, 226, 30, 50, 33, 205, 18, 67, 199, 224, 246, 35, 107 } });

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoutes_CityId",
                table: "TransportRoutes",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_Cities_CityId",
                table: "TransportRoutes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_Cities_CityId",
                table: "TransportRoutes");

            migrationBuilder.DropIndex(
                name: "IX_TransportRoutes_CityId",
                table: "TransportRoutes");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "TransportRoutes");

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "SaltPassword", "SaltValue" },
                values: new object[] { new byte[] { 179, 116, 232, 248, 45, 66, 50, 216, 71, 167, 174, 126, 161, 156, 7, 15, 1, 180, 238, 187, 20, 54, 156, 229, 208, 213, 38, 9, 101, 129, 20, 29 }, new byte[] { 242, 3, 62, 221, 169, 59, 244, 197, 207, 234, 53, 50, 77, 20, 139, 149, 229, 94, 234, 17, 19, 5, 169, 55, 184, 124, 139, 169, 205, 6, 47, 224 } });
        }
    }
}
