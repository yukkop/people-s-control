using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class HCSnullableObjectsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs");

            migrationBuilder.AlterColumn<long>(
                name: "TelegramChannelId",
                table: "HCSs",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ResponsiblePersonId",
                table: "HCSs",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "HCSs",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs");

            migrationBuilder.AlterColumn<long>(
                name: "TelegramChannelId",
                table: "HCSs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsiblePersonId",
                table: "HCSs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "HCSs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
