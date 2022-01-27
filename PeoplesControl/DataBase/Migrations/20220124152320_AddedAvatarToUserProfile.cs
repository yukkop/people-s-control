using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddedAvatarToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AvatarId",
                table: "UsersProfiles",
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

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_AvatarId",
                table: "UsersProfiles",
                column: "AvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Avatars_AvatarId",
                table: "UsersProfiles",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Avatars_AvatarId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_AvatarId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "UsersProfiles");

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
        }
    }
}
