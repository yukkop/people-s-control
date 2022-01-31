using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBase.Migrations
{
    public partial class ForeignKeysForAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReports_Users_UserId",
                table: "DraftReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_DraftReports_DraftReportId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_HCSTypes_HCSTypeId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_HCSs_HCSId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByRegions_HCSs_HCSId",
                table: "HCSsByRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByRegions_SupportedRegions_SupportedRegionId",
                table: "HCSsByRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_HCSs_HCSId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_Reports_ReportId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_MailingStatuses_MailingStatusId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_DraftReports_DraftReportId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_Reports_ReportId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_MediaDataTypes_TypeId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportStatuses_StatusId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_ProblemCategor~",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_Reports_ReportId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsViews_Reports_ReportId",
                table: "ReportsViews");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsViews_Users_UserId",
                table: "ReportsViews");

            migrationBuilder.DropForeignKey(
                name: "FK_StopsOnRoutes_TransportRoutes_TransportRouteId",
                table: "StopsOnRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_StopsOnRoutes_TransportStops_TransportStopId",
                table: "StopsOnRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStopActions_StopsOnRoutes_StopingPointOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_Cities_CityId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Districts_LocationId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Roles_RoleId",
                table: "UsersRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles");

            migrationBuilder.DropTable(
                name: "DriversRoutes");

            migrationBuilder.DropTable(
                name: "SupportedRegions");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_LocationId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TransportStopActions_StopingPointOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropIndex(
                name: "IX_HCSsByRegions_SupportedRegionId",
                table: "HCSsByRegions");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "StopingPointOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropColumn(
                name: "SupportedRegionId",
                table: "HCSsByRegions");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UsersRoles",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "UsersRoles",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DistrictId",
                table: "UsersProfiles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "UserProfileId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TransportCompanyId",
                table: "TransportStops",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "TransportStops",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StopOnRouteId",
                table: "TransportStopActions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "TransportStopId",
                table: "StopsOnRoutes",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TransportRouteId",
                table: "StopsOnRoutes",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ReportsViews",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "ReportsViews",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "ReportsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "ReportsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RelationReportId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ModeratorId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "ProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                table: "MediaDatas",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "MediaDatas",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DraftReportId",
                table: "MediaDatas",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MailingStatusId",
                table: "MailingQueues",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "HCSTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HCSTaskTypeId",
                table: "HCSTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSTasks",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSsByRegions",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "HCSsByRegions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "HCSsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResponsiblePersonId",
                table: "HCSs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HCSTypeId",
                table: "HCSs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "HCSs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "DraftReportsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DraftReportId",
                table: "DraftReportsByProblemCategories",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "DraftReports",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ActionMeta",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DriversOnRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<long>(nullable: false),
                    TransportRouteId = table.Column<long>(nullable: false),
                    VehicleNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversOnRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversOnRoutes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriversOnRoutes_TransportRoutes_TransportRouteId",
                        column: x => x.TransportRouteId,
                        principalTable: "TransportRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<long>(nullable: false),
                    IsRegionSupported = table.Column<bool>(nullable: false),
                    QueuePosition = table.Column<long>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Regions_ActionMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regions_ActionMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Regions_ActionMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_DistrictId",
                table: "UsersProfiles",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStopActions_StopOnRouteId",
                table: "TransportStopActions",
                column: "StopOnRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByRegions_RegionId",
                table: "HCSsByRegions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversOnRoutes_DriverId",
                table: "DriversOnRoutes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversOnRoutes_TransportRouteId",
                table: "DriversOnRoutes",
                column: "TransportRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CreationId",
                table: "Regions",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_LastEditingId",
                table: "Regions",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RemovalId",
                table: "Regions",
                column: "RemovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReports_Users_UserId",
                table: "DraftReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_DraftReports_DraftReportId",
                table: "DraftReportsByProblemCategories",
                column: "DraftReportId",
                principalTable: "DraftReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_HCSTypes_HCSTypeId",
                table: "HCSs",
                column: "HCSTypeId",
                principalTable: "HCSTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByProblemCategories_HCSs_HCSId",
                table: "HCSsByProblemCategories",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByRegions_HCSs_HCSId",
                table: "HCSsByRegions",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByRegions_Regions_RegionId",
                table: "HCSsByRegions",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_HCSs_HCSId",
                table: "HCSTasks",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks",
                column: "HCSTaskTypeId",
                principalTable: "HCSTaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_Reports_ReportId",
                table: "HCSTasks",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_MailingStatuses_MailingStatusId",
                table: "MailingQueues",
                column: "MailingStatusId",
                principalTable: "MailingStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_DraftReports_DraftReportId",
                table: "MediaDatas",
                column: "DraftReportId",
                principalTable: "DraftReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_Reports_ReportId",
                table: "MediaDatas",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_MediaDataTypes_TypeId",
                table: "MediaDatas",
                column: "TypeId",
                principalTable: "MediaDataTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports",
                column: "RelationReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportStatuses_StatusId",
                table: "Reports",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_ProblemCategor~",
                table: "ReportsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsByProblemCategories_Reports_ReportId",
                table: "ReportsByProblemCategories",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsViews_Reports_ReportId",
                table: "ReportsViews",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsViews_Users_UserId",
                table: "ReportsViews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StopsOnRoutes_TransportRoutes_TransportRouteId",
                table: "StopsOnRoutes",
                column: "TransportRouteId",
                principalTable: "TransportRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StopsOnRoutes_TransportStops_TransportStopId",
                table: "StopsOnRoutes",
                column: "TransportStopId",
                principalTable: "TransportStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStopActions_StopsOnRoutes_StopOnRouteId",
                table: "TransportStopActions",
                column: "StopOnRouteId",
                principalTable: "StopsOnRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_Cities_CityId",
                table: "TransportStops",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops",
                column: "TransportCompanyId",
                principalTable: "TransportCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Districts_DistrictId",
                table: "UsersProfiles",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Roles_RoleId",
                table: "UsersRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReports_Users_UserId",
                table: "DraftReports");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_DraftReports_DraftReportId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_HCSTypes_HCSTypeId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_HCSs_HCSId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByRegions_HCSs_HCSId",
                table: "HCSsByRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByRegions_Regions_RegionId",
                table: "HCSsByRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_HCSs_HCSId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_Reports_ReportId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MailingQueues_MailingStatuses_MailingStatusId",
                table: "MailingQueues");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_DraftReports_DraftReportId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_Reports_ReportId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaDatas_MediaDataTypes_TypeId",
                table: "MediaDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReportStatuses_StatusId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_ProblemCategor~",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_Reports_ReportId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsViews_Reports_ReportId",
                table: "ReportsViews");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsViews_Users_UserId",
                table: "ReportsViews");

            migrationBuilder.DropForeignKey(
                name: "FK_StopsOnRoutes_TransportRoutes_TransportRouteId",
                table: "StopsOnRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_StopsOnRoutes_TransportStops_TransportStopId",
                table: "StopsOnRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStopActions_StopsOnRoutes_StopOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_Cities_CityId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProfiles_Districts_DistrictId",
                table: "UsersProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Roles_RoleId",
                table: "UsersRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles");

            migrationBuilder.DropTable(
                name: "DriversOnRoutes");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_UsersProfiles_DistrictId",
                table: "UsersProfiles");

            migrationBuilder.DropIndex(
                name: "IX_TransportStopActions_StopOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropIndex(
                name: "IX_HCSsByRegions_RegionId",
                table: "HCSsByRegions");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "UsersProfiles");

            migrationBuilder.DropColumn(
                name: "StopOnRouteId",
                table: "TransportStopActions");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "HCSsByRegions");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UsersRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "UsersRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "LocationId",
                table: "UsersProfiles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserProfileId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "TransportCompanyId",
                table: "TransportStops",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "TransportStops",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "StopingPointOnRouteId",
                table: "TransportStopActions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TransportStopId",
                table: "StopsOnRoutes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "TransportRouteId",
                table: "StopsOnRoutes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ReportsViews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "ReportsViews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "ReportsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "ReportsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Reports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "StatusId",
                table: "Reports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "RelationReportId",
                table: "Reports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ModeratorId",
                table: "Reports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "ProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "TypeId",
                table: "MediaDatas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "MediaDatas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "DraftReportId",
                table: "MediaDatas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "MailingStatusId",
                table: "MailingQueues",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ReportId",
                table: "HCSTasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HCSTaskTypeId",
                table: "HCSTasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSTasks",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSsByRegions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "SupportedRegionId",
                table: "HCSsByRegions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "HCSsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HCSId",
                table: "HCSsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ResponsiblePersonId",
                table: "HCSs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "HCSTypeId",
                table: "HCSs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AvatarId",
                table: "HCSs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "ProblemCategoryId",
                table: "DraftReportsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "DraftReportId",
                table: "DraftReportsByProblemCategories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "DraftReports",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "ActionMeta",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "DriversRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<long>(type: "bigint", nullable: true),
                    TransportRouteId = table.Column<long>(type: "bigint", nullable: true),
                    VehicleNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriversRoutes_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DriversRoutes_TransportRoutes_TransportRouteId",
                        column: x => x.TransportRouteId,
                        principalTable: "TransportRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportedRegions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    CreationId = table.Column<long>(type: "bigint", nullable: true),
                    IsRegionSupported = table.Column<bool>(type: "boolean", nullable: false),
                    LastEditingId = table.Column<long>(type: "bigint", nullable: true),
                    QueuePosition = table.Column<long>(type: "bigint", nullable: false),
                    RemovalId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_ActionMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_ActionMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_ActionMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfiles_LocationId",
                table: "UsersProfiles",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStopActions_StopingPointOnRouteId",
                table: "TransportStopActions",
                column: "StopingPointOnRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByRegions_SupportedRegionId",
                table: "HCSsByRegions",
                column: "SupportedRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversRoutes_DriverId",
                table: "DriversRoutes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversRoutes_TransportRouteId",
                table: "DriversRoutes",
                column: "TransportRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedRegions_CityId",
                table: "SupportedRegions",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedRegions_CreationId",
                table: "SupportedRegions",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedRegions_LastEditingId",
                table: "SupportedRegions",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedRegions_RemovalId",
                table: "SupportedRegions",
                column: "RemovalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMeta_Users_UserId",
                table: "ActionMeta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReports_Users_UserId",
                table: "DraftReports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_DraftReports_DraftReportId",
                table: "DraftReportsByProblemCategories",
                column: "DraftReportId",
                principalTable: "DraftReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Avatars_AvatarId",
                table: "HCSs",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_HCSTypes_HCSTypeId",
                table: "HCSs",
                column: "HCSTypeId",
                principalTable: "HCSTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByProblemCategories_HCSs_HCSId",
                table: "HCSsByProblemCategories",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByRegions_HCSs_HCSId",
                table: "HCSsByRegions",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByRegions_SupportedRegions_SupportedRegionId",
                table: "HCSsByRegions",
                column: "SupportedRegionId",
                principalTable: "SupportedRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_HCSs_HCSId",
                table: "HCSTasks",
                column: "HCSId",
                principalTable: "HCSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks",
                column: "HCSTaskTypeId",
                principalTable: "HCSTaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_Reports_ReportId",
                table: "HCSTasks",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailingQueues_MailingStatuses_MailingStatusId",
                table: "MailingQueues",
                column: "MailingStatusId",
                principalTable: "MailingStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_DraftReports_DraftReportId",
                table: "MediaDatas",
                column: "DraftReportId",
                principalTable: "DraftReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_Reports_ReportId",
                table: "MediaDatas",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaDatas_MediaDataTypes_TypeId",
                table: "MediaDatas",
                column: "TypeId",
                principalTable: "MediaDataTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemCategories_Avatars_AvatarId",
                table: "ProblemCategories",
                column: "AvatarId",
                principalTable: "Avatars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ModeratorId",
                table: "Reports",
                column: "ModeratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Reports_RelationReportId",
                table: "Reports",
                column: "RelationReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReportStatuses_StatusId",
                table: "Reports",
                column: "StatusId",
                principalTable: "ReportStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_ProblemCategor~",
                table: "ReportsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsByProblemCategories_Reports_ReportId",
                table: "ReportsByProblemCategories",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsViews_Reports_ReportId",
                table: "ReportsViews",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsViews_Users_UserId",
                table: "ReportsViews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StopsOnRoutes_TransportRoutes_TransportRouteId",
                table: "StopsOnRoutes",
                column: "TransportRouteId",
                principalTable: "TransportRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StopsOnRoutes_TransportStops_TransportStopId",
                table: "StopsOnRoutes",
                column: "TransportStopId",
                principalTable: "TransportStops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStopActions_StopsOnRoutes_StopingPointOnRouteId",
                table: "TransportStopActions",
                column: "StopingPointOnRouteId",
                principalTable: "StopsOnRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_Cities_CityId",
                table: "TransportStops",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops",
                column: "TransportCompanyId",
                principalTable: "TransportCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersProfiles_UserProfileId",
                table: "Users",
                column: "UserProfileId",
                principalTable: "UsersProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProfiles_Districts_LocationId",
                table: "UsersProfiles",
                column: "LocationId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Roles_RoleId",
                table: "UsersRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRoles_Users_UserId",
                table: "UsersRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
