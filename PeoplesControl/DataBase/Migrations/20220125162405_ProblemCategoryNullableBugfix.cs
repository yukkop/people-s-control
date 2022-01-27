using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ProblemCategoryNullableBugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories");

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "ProblemCategories",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories");

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "ProblemCategories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 17, 11, 19, 187, DateTimeKind.Local).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2022, 1, 25, 17, 11, 19, 188, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
