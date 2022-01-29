using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ImportantInsertHardCodeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "UsersRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4L);

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
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UsersProfiles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ActionMeta",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    {"Донецк"},
                    {"Макеевка"},
                    {"Харцызск"},
                    {"Ясиноватая"},
                }

                );

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] {"CityId", "Name" },
                values: new object[,]
                {
                    {2, "Червоногвардейка"},
                    {2, "Центральногородской"},
                    {2, "Горняцкий"},
                }

                );

            migrationBuilder.InsertData(
                table: "ActionMeta",
                columns: new[] {"UserId", "Date" },
                values: new object[,]
                {
                    {null, DateTime.Now},
                    {null, DateTime.Now},
                    {null, DateTime.Now},
                }

                );
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "CityId", "IsRegionSupported" },
                values: new object[,]
                {
                    {1, true},
                    {2, true},
                    {3, false},
                    {4, false},
                }

                );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] {"Name" },
                values: new object[,]
                {
                    {"Admin"},
                    {"Guest"},
                    {"User"},
                }

                );

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] {"Name", "Surname", "CreationId", "IsBlock",
                                "NotifyByEmail", "NotifyBySMS","RequestAnonymity",
                                "DistrictId"},
                values: new object[,]
                {
                    {"Supper", "Account", 1, false,
                                false, false,false,
                                1},
                    {"Guest", "Account", 2, false,
                                false, false,false,
                                1}
                }

                );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] {"UserProfileId", "Login", "SaltPassword", "SaltValue" },
                values: new object[,]
                {
                    { 1, "supper", Properties.Resources.SupperSaltPassword,Properties.Resources.SupperSaltValue},

                    { 2, "guest", Properties.Resources.GuestSaltPassword,Properties.Resources.GuestSaltValue},

                }

                );

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1,1},
                    { 2,2},

                }

                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActionMeta",
                columns: new[] { "Id", "Date", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 28, 18, 50, 4, 52, DateTimeKind.Local).AddTicks(438), null },
                    { 2L, new DateTime(2022, 1, 28, 18, 50, 4, 53, DateTimeKind.Local).AddTicks(2510), null },
                    { 3L, new DateTime(2022, 1, 28, 18, 50, 4, 53, DateTimeKind.Local).AddTicks(2536), null }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] {"Id", "Name" },
                values: new object[,]
                {
                    {1L, "Донецк" },
                    {2L, "Макеевка" },
                    {3L, "Харцызск" },
                    {4L, "Ясиноватая" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreationId", "LastEditingId", "MnemonicName", "Name", "RemovalId" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Admin", null },
                    { 2L, null, null, null, "Guest", null },
                    { 3L, null, null, null, " User", null }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1L, 2L, "Червоногвардейка" },
                    { 2L, 2L, "Центральногородской" },
                    { 3L, 2L, "Горняцкий" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CityId", "CreationId", "IsRegionSupported", "LastEditingId", "RemovalId" },
                values: new object[,]
                {
                    { 1L, 1L, null, true, null, null },
                    { 2L, 2L, null, true, null, null },
                    { 3L, 3L, null, false, null, null },
                    { 4L, 4L, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "UsersProfiles",
                columns: new[] { "Id", "AvatarId", "BlockId", "CreationId", "DistrictId", "EmailAddress", "IsBlock", "LastEditingId", "Name", "NotifyByEmail", "NotifyBySMS", "Patronymic", "PhoneNumber", "RemovalId", "RequestAnonymity", "Surname", "UnblockId" },
                values: new object[,]
                {
                    { 1L, null, null, 1L, 1L, null, false, null, "Supper", false, false, null, null, null, false, "Account", null },
                    { 2L, null, null, 2L, 1L, null, false, null, "Guest", false, false, null, null, null, true, "Account", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateEmailConfirmation", "DateSMSConfirmation", "EmailConfirmationCode", "Login", "SMSConfirmationCode", "SaltPassword", "SaltValue", "UserProfileId" },
                values: new object[,]
                {
                    { 1L, null, null, null, "supper", null, new byte[] { 179, 116, 232, 248, 45, 66, 50, 216, 71, 167, 174, 126, 161, 156, 7, 15, 1, 180, 238, 187, 20, 54, 156, 229, 208, 213, 38, 9, 101, 129, 20, 29 }, new byte[] { 242, 3, 62, 221, 169, 59, 244, 197, 207, 234, 53, 50, 77, 20, 139, 149, 229, 94, 234, 17, 19, 5, 169, 55, 184, 124, 139, 169, 205, 6, 47, 224 }, 1L },
                    { 2L, null, null, null, "guest", null, new byte[] { 133, 17, 106, 142, 11, 55, 24, 255, 120, 66, 77, 48, 20, 232, 1, 81, 30, 78, 164, 83, 42, 224, 147, 224, 37, 147, 105, 53, 170, 172, 249, 108 }, new byte[] { 97, 234, 60, 207, 110, 168, 164, 13, 64, 190, 70, 8, 4, 203, 74, 107, 187, 80, 160, 123, 226, 30, 50, 33, 205, 18, 67, 199, 224, 246, 35, 107 }, 2L }
                });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 2L, 2L }
                });
        }
    }
}
