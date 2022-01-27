using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class SuperUserAdditionTry1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "Sername",
                table: "UsersProfiles");

            migrationBuilder.AlterColumn<long>(
                name: "CreationId",
                table: "UsersProfiles",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "UsersProfiles",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ActionMeta",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "ActionMeta",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[] { 1L, new DateTime(2022, 1, 21, 23, 20, 6, 830, DateTimeKind.Local).AddTicks(5240), null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Донецк" },
                    { 2L, "Макеевка" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1L, 2L, "Червоногвардейка" });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "BlockId", "CreationId", "DistrictId", "EmailAdress", "IsBlock", "LastEditingId", "Name", "NotifyByEmail", "NotifyBySMS", "Patronymic", "PhoneNumber", "RemovalId", "RequestAnonymity", "Surname", "UnblockId" },
                values: new object[] { 1L, null, 1L, 1L, null, false, null, "Supper", false, false, null, null, null, false, "Account", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateEmailConfirmation", "DateSMSConfirmation", "EmailConfirmationCode", "Login", "SMSConfirmationCode", "SaltPassword", "SaltValue", "UserProfileId" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "supper", 0, new byte[] {  }, new byte[] {  }, 1L });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "UsersProfiles");

            migrationBuilder.AlterColumn<long>(
                name: "CreationId",
                table: "UsersProfiles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Sername",
                table: "UsersProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ActionMeta",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
