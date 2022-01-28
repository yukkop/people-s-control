using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ImplimentRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueuePosition",
                table: "Regions");

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

            migrationBuilder.InsertData(
                table: "ActionMeta",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[] { 3L, new DateTime(2022, 1, 28, 14, 4, 21, 715, DateTimeKind.Local).AddTicks(6040), null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3L, "Харцызск" },
                    { 4L, "Ясиноватая" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 2L, 2L, "Центральногородской" },
                    { 3L, 2L, "Горняцкий" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CityId", "CreationId", "IsRegionSupported", "LastEditingId", "RemovalId" },
                values: new object[,]
                {
                    { 1L, 1L, null, true, null, null },
                    { 2L, 2L, null, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationId", "LastEditingId", "MnemonicName", "Name", "RemovalId" },
                values: new object[] { 3L, null, null, null, " User", null });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CityId", "CreationId", "IsRegionSupported", "LastEditingId", "RemovalId" },
                values: new object[,]
                {
                    { 3L, 3L, null, false, null, null },
                    { 4L, 4L, null, false, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<long>(
                name: "QueuePosition",
                table: "Regions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 19, 24, 5, 254, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 19, 24, 5, 255, DateTimeKind.Local).AddTicks(611));
        }
    }
}
