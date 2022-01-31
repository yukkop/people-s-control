using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class DistrictForeignKeyWithNameCityIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionsMeta_Users_UserId",
                table: "ActionsMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionsMeta_CreationId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionsMeta_LastEditingId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionsMeta_RemovalId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionsMeta_CreationId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionsMeta_LastEditingId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionsMeta_RemovalId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionsMeta_CreationId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionsMeta_LastEditingId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionsMeta_RemovalId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_CreationId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_LastEditingId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_RemovalId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionsMeta_CreationId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionsMeta_LastEditingId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionsMeta_RemovalId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_CreationId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_LastEditingId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_RemovalId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_CreationId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_LastEditingId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_RemovalId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionsMeta_CreationId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionsMeta_LastEditingId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionsMeta_RemovalId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_BlockId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_CreationId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_LastEditingId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_RemovalId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_UnblockId",
                table: "UsersProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionsMeta",
                table: "ActionsMeta");

            migrationBuilder.RenameTable(
                name: "ActionsMeta",
                newName: "ActionMeta");

            migrationBuilder.RenameIndex(
                name: "IX_ActionsMeta_UserId",
                table: "ActionMeta",
                newName: "IX_ActionMeta_UserId");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Districts",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionMeta",
                table: "ActionMeta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionMeta_CreationId",
                table: "HCSs",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionMeta_LastEditingId",
                table: "HCSs",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionMeta_RemovalId",
                table: "HCSs",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionMeta_CreationId",
                table: "HCSTasks",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionMeta_LastEditingId",
                table: "HCSTasks",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionMeta_RemovalId",
                table: "HCSTasks",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionMeta_CreationId",
                table: "MailingQueues",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionMeta_LastEditingId",
                table: "MailingQueues",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionMeta_RemovalId",
                table: "MailingQueues",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionMeta_CreationId",
                table: "ProblemCategories",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionMeta_LastEditingId",
                table: "ProblemCategories",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionMeta_RemovalId",
                table: "ProblemCategories",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionMeta_CreationId",
                table: "Roles",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionMeta_LastEditingId",
                table: "Roles",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionMeta_RemovalId",
                table: "Roles",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionMeta_CreationId",
                table: "SupportedRegions",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionMeta_LastEditingId",
                table: "SupportedRegions",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionMeta_RemovalId",
                table: "SupportedRegions",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionMeta_CreationId",
                table: "TransportRoutes",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionMeta_LastEditingId",
                table: "TransportRoutes",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionMeta_RemovalId",
                table: "TransportRoutes",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionMeta_CreationId",
                table: "TransportStops",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionMeta_LastEditingId",
                table: "TransportStops",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionMeta_RemovalId",
                table: "TransportStops",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_BlockId",
                table: "UsersProfiles",
                column: "BlockId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles",
                column: "CreationId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_LastEditingId",
                table: "UsersProfiles",
                column: "LastEditingId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_RemovalId",
                table: "UsersProfiles",
                column: "RemovalId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionMeta_UnblockId",
                table: "UsersProfiles",
                column: "UnblockId",
                principalTable: "ActionMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionMeta_CreationId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionMeta_LastEditingId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_ActionMeta_RemovalId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionMeta_CreationId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionMeta_LastEditingId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_ActionMeta_RemovalId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionMeta_CreationId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionMeta_LastEditingId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_ActionMeta_RemovalId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionMeta_CreationId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionMeta_LastEditingId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_ActionMeta_RemovalId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionMeta_CreationId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionMeta_LastEditingId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_ActionMeta_RemovalId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionMeta_CreationId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionMeta_LastEditingId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_SupportedRegions_ActionMeta_RemovalId",
                table: "SupportedRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionMeta_CreationId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionMeta_LastEditingId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportRoutes_ActionMeta_RemovalId",
                table: "TransportRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionMeta_CreationId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionMeta_LastEditingId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_ActionMeta_RemovalId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_BlockId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_CreationId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_LastEditingId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_RemovalId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_ActionMeta_UnblockId",
                table: "UsersProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionMeta",
                table: "ActionMeta");

            migrationBuilder.RenameTable(
                name: "ActionMeta",
                newName: "ActionsMeta");

            migrationBuilder.RenameIndex(
                name: "IX_ActionMeta_UserId",
                table: "ActionsMeta",
                newName: "IX_ActionsMeta_UserId");

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Districts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionsMeta",
                table: "ActionsMeta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionsMeta_Users_UserId",
                table: "ActionsMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionsMeta_CreationId",
                table: "HCSs",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionsMeta_LastEditingId",
                table: "HCSs",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_ActionsMeta_RemovalId",
                table: "HCSs",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionsMeta_CreationId",
                table: "HCSTasks",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionsMeta_LastEditingId",
                table: "HCSTasks",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_ActionsMeta_RemovalId",
                table: "HCSTasks",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionsMeta_CreationId",
                table: "MailingQueues",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionsMeta_LastEditingId",
                table: "MailingQueues",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_ActionsMeta_RemovalId",
                table: "MailingQueues",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_CreationId",
                table: "ProblemCategories",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_LastEditingId",
                table: "ProblemCategories",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_ActionsMeta_RemovalId",
                table: "ProblemCategories",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionsMeta_CreationId",
                table: "Roles",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionsMeta_LastEditingId",
                table: "Roles",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_ActionsMeta_RemovalId",
                table: "Roles",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_CreationId",
                table: "SupportedRegions",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_LastEditingId",
                table: "SupportedRegions",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupportedRegions_ActionsMeta_RemovalId",
                table: "SupportedRegions",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_CreationId",
                table: "TransportRoutes",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_LastEditingId",
                table: "TransportRoutes",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportRoutes_ActionsMeta_RemovalId",
                table: "TransportRoutes",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionsMeta_CreationId",
                table: "TransportStops",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionsMeta_LastEditingId",
                table: "TransportStops",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_ActionsMeta_RemovalId",
                table: "TransportStops",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_BlockId",
                table: "UsersProfiles",
                column: "BlockId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_CreationId",
                table: "UsersProfiles",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_LastEditingId",
                table: "UsersProfiles",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_RemovalId",
                table: "UsersProfiles",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_ActionsMeta_UnblockId",
                table: "UsersProfiles",
                column: "UnblockId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
