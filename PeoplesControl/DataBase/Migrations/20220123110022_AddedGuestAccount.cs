using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddedGuestAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 23, 14, 0, 21, 591, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.InsertData(
                table: "ActionMeta",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[] { 2L, new DateTime(2022, 1, 23, 14, 0, 21, 592, DateTimeKind.Local).AddTicks(6222), null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationId", "LastEditingId", "MnemonicName", "Name", "RemovalId" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Админ", null },
                    { 2L, null, null, null, "Гость", null }
                });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "BlockId", "CreationId", "DistrictId", "EmailAddress", "IsBlock", "LastEditingId", "Name", "NotifyByEmail", "NotifyBySMS", "Patronymic", "PhoneNumber", "RemovalId", "RequestAnonymity", "Surname", "UnblockId" },
                values: new object[] { 2L, null, 2L, 1L, null, false, null, "Guest", false, false, null, null, null, true, "Account", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateEmailConfirmation", "DateSMSConfirmation", "EmailConfirmationCode", "Login", "SMSConfirmationCode", "SaltPassword", "SaltValue", "UserProfileId" },
                values: new object[] { 2L, null, null, null, "guest", null, new byte[] { 179, 116, 232, 248, 45, 66, 50, 216, 71, 167, 174, 126, 161, 156, 7, 15, 1, 180, 238, 187, 20, 54, 156, 229, 208, 213, 38, 9, 101, 129, 20, 29 }, new byte[] { 242, 3, 62, 221, 169, 59, 244, 197, 207, 234, 53, 50, 77, 20, 139, 149, 229, 94, 234, 17, 19, 5, 169, 55, 184, 124, 139, 169, 205, 6, 47, 224 }, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 22, 17, 14, 31, 672, DateTimeKind.Local).AddTicks(4453));
        }
    }
}
