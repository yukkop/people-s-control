using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBase.Migrations
{
    public partial class UniqCityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "UserProfileId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersProfiles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Sername = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAdress = table.Column<string>(nullable: true),
                    LocationId = table.Column<long>(nullable: true),
                    NotifyByEmail = table.Column<bool>(nullable: false),
                    NotifyBySMS = table.Column<bool>(nullable: false),
                    RequestAnonymity = table.Column<bool>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true),
                    IsBlock = table.Column<bool>(nullable: false),
                    BlockId = table.Column<long>(nullable: true),
                    UnblockId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_ActionsMeta_BlockId",
                        column: x => x.BlockId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_Districts_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersProfiles_ActionsMeta_UnblockId",
                        column: x => x.UnblockId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProfileId",
                table: "Users",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_BlockId",
                table: "UsersProfiles",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_CreationId",
                table: "UsersProfiles",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_LastEditingId",
                table: "UsersProfiles",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_LocationId",
                table: "UsersProfiles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_RemovalId",
                table: "UsersProfiles",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_UnblockId",
                table: "UsersProfiles",
                column: "UnblockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "ProfileId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockId = table.Column<long>(type: "bigint", nullable: true),
                    CreationId = table.Column<long>(type: "bigint", nullable: true),
                    EmailAdress = table.Column<string>(type: "text", nullable: true),
                    IsBlock = table.Column<bool>(type: "boolean", nullable: false),
                    LastEditingId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NotifyByEmail = table.Column<bool>(type: "boolean", nullable: false),
                    NotifyBySMS = table.Column<bool>(type: "boolean", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    RemovalId = table.Column<long>(type: "bigint", nullable: true),
                    RequestAnonymity = table.Column<bool>(type: "boolean", nullable: false),
                    Sername = table.Column<string>(type: "text", nullable: true),
                    UnblockId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_ActionsMeta_BlockId",
                        column: x => x.BlockId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_Districts_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profiles_ActionsMeta_UnblockId",
                        column: x => x.UnblockId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_BlockId",
                table: "Profiles",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CreationId",
                table: "Profiles",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LastEditingId",
                table: "Profiles",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_LocationId",
                table: "Profiles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_RemovalId",
                table: "Profiles",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UnblockId",
                table: "Profiles",
                column: "UnblockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
