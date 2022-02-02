using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NpgsqlTypes;

namespace DataBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avatars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HCSTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailingStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaDataTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDataTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HCSs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MnemonicName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ResponsiblePersonId = table.Column<long>(nullable: true),
                    AvatarId = table.Column<long>(nullable: true),
                    Hashtag = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    MinistryEmail = table.Column<string>(nullable: true),
                    TelegramChannelId = table.Column<long>(nullable: false),
                    WebResourseURL = table.Column<string>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    HCSTypeId = table.Column<long>(nullable: true),
                    IsEmailMailingEnabled = table.Column<bool>(nullable: false),
                    IsSMSMailingEnabled = table.Column<bool>(nullable: false),
                    IsDailyReportsGenerating = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCSs_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HCSs_HCSTypes_HCSTypeId",
                        column: x => x.HCSTypeId,
                        principalTable: "HCSTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    HCSId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_HCSs_HCSId",
                        column: x => x.HCSId,
                        principalTable: "HCSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HCSTasks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HCSId = table.Column<long>(nullable: true),
                    ReportId = table.Column<long>(nullable: true),
                    TaskTypeId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCSTasks_HCSs_HCSId",
                        column: x => x.HCSId,
                        principalTable: "HCSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HCSTasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MailingQueues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MailingStatusId = table.Column<long>(nullable: true),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailingQueues_MailingStatuses_MailingStatusId",
                        column: x => x.MailingStatusId,
                        principalTable: "MailingStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProblemCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MnemonicName = table.Column<string>(nullable: true),
                    HashTag = table.Column<string>(nullable: true),
                    AvatarId = table.Column<long>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProblemCategories_Avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Avatars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HCSsByProblemCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HCSId = table.Column<long>(nullable: true),
                    MyPropertyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSsByProblemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCSsByProblemCategories_HCSs_HCSId",
                        column: x => x.HCSId,
                        principalTable: "HCSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HCSsByProblemCategories_ProblemCategories_MyPropertyId",
                        column: x => x.MyPropertyId,
                        principalTable: "ProblemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
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
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Districts_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<long>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    SaltPassword = table.Column<byte[]>(nullable: true),
                    SaltValue = table.Column<byte[]>(nullable: true),
                    SMSConfirmationCode = table.Column<int>(nullable: false),
                    EmailConfirmationCode = table.Column<int>(nullable: false),
                    DateSMSConfirmation = table.Column<DateTime>(nullable: false),
                    DateEmailConfirmation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionsMeta",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionsMeta_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftReports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Сoordinates = table.Column<NpgsqlPoint>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateRemoval = table.Column<DateTime>(nullable: false),
                    DateLastEditing = table.Column<DateTime>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    RelationReportId = table.Column<long>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    StatusId = table.Column<long>(nullable: true),
                    Coordinates = table.Column<NpgsqlPoint>(nullable: false),
                    DateConsideration = table.Column<DateTime>(nullable: false),
                    DateStartExecution = table.Column<DateTime>(nullable: false),
                    DateFinishExecution = table.Column<DateTime>(nullable: false),
                    DateFinalControl = table.Column<DateTime>(nullable: false),
                    IsRequestModeration = table.Column<bool>(nullable: false),
                    ModeratorId = table.Column<long>(nullable: true),
                    ProblemDescription = table.Column<string>(nullable: true),
                    BaseRate = table.Column<float>(nullable: false),
                    DateRemoval = table.Column<DateTime>(nullable: false),
                    DateLastEditing = table.Column<DateTime>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ModeratorId",
                        column: x => x.ModeratorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Reports_RelationReportId",
                        column: x => x.RelationReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_ReportStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ReportStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    MnemonicName = table.Column<string>(nullable: true),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportedRegions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<long>(nullable: true),
                    IsRegionSupported = table.Column<bool>(nullable: false),
                    QueuePosition = table.Column<long>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
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
                        name: "FK_SupportedRegions_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedRegions_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportRoutes_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportRoutes_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportRoutes_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportStops",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    ManagementCompanieId = table.Column<long>(nullable: true),
                    Сoordinates = table.Column<NpgsqlPoint>(nullable: false),
                    CityId = table.Column<long>(nullable: true),
                    RemovalId = table.Column<long>(nullable: true),
                    LastEditingId = table.Column<long>(nullable: true),
                    CreationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportStops_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportStops_ActionsMeta_CreationId",
                        column: x => x.CreationId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportStops_ActionsMeta_LastEditingId",
                        column: x => x.LastEditingId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportStops_TransportCompanies_ManagementCompanieId",
                        column: x => x.ManagementCompanieId,
                        principalTable: "TransportCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransportStops_ActionsMeta_RemovalId",
                        column: x => x.RemovalId,
                        principalTable: "ActionsMeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftReportsByProblemCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DraftReportId = table.Column<long>(nullable: true),
                    CategorieOfProblemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftReportsByProblemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftReportsByProblemCategories_ProblemCategories_Categorie~",
                        column: x => x.CategorieOfProblemId,
                        principalTable: "ProblemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftReportsByProblemCategories_DraftReports_DraftReportId",
                        column: x => x.DraftReportId,
                        principalTable: "DraftReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaDatas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<long>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    DraftReportId = table.Column<long>(nullable: true),
                    ReportId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaDatas_DraftReports_DraftReportId",
                        column: x => x.DraftReportId,
                        principalTable: "DraftReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaDatas_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MediaDatas_MediaDataTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "MediaDataTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportsByProblemCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportId = table.Column<long>(nullable: true),
                    CategorieOfProblemId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsByProblemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsByProblemCategories_ProblemCategories_CategorieOfPro~",
                        column: x => x.CategorieOfProblemId,
                        principalTable: "ProblemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportsByProblemCategories_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportsViews",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(nullable: true),
                    ReportId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsViews_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportsViews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HCSsByRegions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HCSId = table.Column<long>(nullable: true),
                    SupportedRegionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSsByRegions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HCSsByRegions_HCSs_HCSId",
                        column: x => x.HCSId,
                        principalTable: "HCSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HCSsByRegions_SupportedRegions_SupportedRegionId",
                        column: x => x.SupportedRegionId,
                        principalTable: "SupportedRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriversRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DriverId = table.Column<long>(nullable: true),
                    TransportRouteId = table.Column<long>(nullable: true),
                    VehicleNumber = table.Column<string>(nullable: true)
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
                name: "StopsOnRoutes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransportStopId = table.Column<long>(nullable: true),
                    TransportRouteId = table.Column<long>(nullable: true),
                    PositionNumber = table.Column<int>(nullable: false),
                    IsStart = table.Column<bool>(nullable: false),
                    IsFinish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopsOnRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StopsOnRoutes_TransportRoutes_TransportRouteId",
                        column: x => x.TransportRouteId,
                        principalTable: "TransportRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StopsOnRoutes_TransportStops_TransportStopId",
                        column: x => x.TransportStopId,
                        principalTable: "TransportStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransportStopActions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StopingPointOnRouteId = table.Column<long>(nullable: true),
                    ArrivalTime = table.Column<TimeSpan>(nullable: false),
                    DepartureTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportStopActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportStopActions_StopsOnRoutes_StopingPointOnRouteId",
                        column: x => x.StopingPointOnRouteId,
                        principalTable: "StopsOnRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionsMeta_UserId",
                table: "ActionsMeta",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReports_UserId",
                table: "DraftReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReportsByProblemCategories_CategorieOfProblemId",
                table: "DraftReportsByProblemCategories",
                column: "CategorieOfProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReportsByProblemCategories_DraftReportId",
                table: "DraftReportsByProblemCategories",
                column: "DraftReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversRoutes_DriverId",
                table: "DriversRoutes",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriversRoutes_TransportRouteId",
                table: "DriversRoutes",
                column: "TransportRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_AvatarId",
                table: "HCSs",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_CreationId",
                table: "HCSs",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_HCSTypeId",
                table: "HCSs",
                column: "HCSTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_LastEditingId",
                table: "HCSs",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_RemovalId",
                table: "HCSs",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSs_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByProblemCategories_HCSId",
                table: "HCSsByProblemCategories",
                column: "HCSId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByProblemCategories_MyPropertyId",
                table: "HCSsByProblemCategories",
                column: "MyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByRegions_HCSId",
                table: "HCSsByRegions",
                column: "HCSId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByRegions_SupportedRegionId",
                table: "HCSsByRegions",
                column: "SupportedRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_CreationId",
                table: "HCSTasks",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_HCSId",
                table: "HCSTasks",
                column: "HCSId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_LastEditingId",
                table: "HCSTasks",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_RemovalId",
                table: "HCSTasks",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_ReportId",
                table: "HCSTasks",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_TaskTypeId",
                table: "HCSTasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingQueues_CreationId",
                table: "MailingQueues",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingQueues_LastEditingId",
                table: "MailingQueues",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingQueues_MailingStatusId",
                table: "MailingQueues",
                column: "MailingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MailingQueues_RemovalId",
                table: "MailingQueues",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaDatas_DraftReportId",
                table: "MediaDatas",
                column: "DraftReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaDatas_ReportId",
                table: "MediaDatas",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaDatas_TypeId",
                table: "MediaDatas",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemCategories_AvatarId",
                table: "ProblemCategories",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemCategories_CreationId",
                table: "ProblemCategories",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemCategories_LastEditingId",
                table: "ProblemCategories",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemCategories_RemovalId",
                table: "ProblemCategories",
                column: "RemovalId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ModeratorId",
                table: "Reports",
                column: "ModeratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_RelationReportId",
                table: "Reports",
                column: "RelationReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StatusId",
                table: "Reports",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsByProblemCategories_CategorieOfProblemId",
                table: "ReportsByProblemCategories",
                column: "CategorieOfProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsByProblemCategories_ReportId",
                table: "ReportsByProblemCategories",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsViews_ReportId",
                table: "ReportsViews",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsViews_UserId",
                table: "ReportsViews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreationId",
                table: "Roles",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LastEditingId",
                table: "Roles",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RemovalId",
                table: "Roles",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_HCSId",
                table: "Schedules",
                column: "HCSId");

            migrationBuilder.CreateIndex(
                name: "IX_StopsOnRoutes_TransportRouteId",
                table: "StopsOnRoutes",
                column: "TransportRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_StopsOnRoutes_TransportStopId",
                table: "StopsOnRoutes",
                column: "TransportStopId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoutes_CreationId",
                table: "TransportRoutes",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoutes_LastEditingId",
                table: "TransportRoutes",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoutes_RemovalId",
                table: "TransportRoutes",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStopActions_StopingPointOnRouteId",
                table: "TransportStopActions",
                column: "StopingPointOnRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_CityId",
                table: "TransportStops",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_CreationId",
                table: "TransportStops",
                column: "CreationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_LastEditingId",
                table: "TransportStops",
                column: "LastEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_ManagementCompanieId",
                table: "TransportStops",
                column: "ManagementCompanieId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_RemovalId",
                table: "TransportStops",
                column: "RemovalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId",
                table: "UsersRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HCSs_Users_ResponsiblePersonId",
                table: "HCSs",
                column: "ResponsiblePersonId",
                principalTable: "Users",
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
                name: "FK_HCSTasks_Reports_ReportId",
                table: "HCSTasks",
                column: "ReportId",
                principalTable: "Reports",
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
                name: "FK_Profiles_ActionsMeta_BlockId",
                table: "Profiles",
                column: "BlockId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ActionsMeta_CreationId",
                table: "Profiles",
                column: "CreationId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ActionsMeta_LastEditingId",
                table: "Profiles",
                column: "LastEditingId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ActionsMeta_RemovalId",
                table: "Profiles",
                column: "RemovalId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_ActionsMeta_UnblockId",
                table: "Profiles",
                column: "UnblockId",
                principalTable: "ActionsMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionsMeta_Users_UserId",
                table: "ActionsMeta");

            migrationBuilder.DropTable(
                name: "DraftReportsByProblemCategories");

            migrationBuilder.DropTable(
                name: "DriversRoutes");

            migrationBuilder.DropTable(
                name: "HCSsByProblemCategories");

            migrationBuilder.DropTable(
                name: "HCSsByRegions");

            migrationBuilder.DropTable(
                name: "HCSTasks");

            migrationBuilder.DropTable(
                name: "MailingQueues");

            migrationBuilder.DropTable(
                name: "MediaDatas");

            migrationBuilder.DropTable(
                name: "ReportsByProblemCategories");

            migrationBuilder.DropTable(
                name: "ReportsViews");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "TransportStopActions");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "SupportedRegions");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "MailingStatuses");

            migrationBuilder.DropTable(
                name: "DraftReports");

            migrationBuilder.DropTable(
                name: "MediaDataTypes");

            migrationBuilder.DropTable(
                name: "ProblemCategories");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "HCSs");

            migrationBuilder.DropTable(
                name: "StopsOnRoutes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ReportStatuses");

            migrationBuilder.DropTable(
                name: "Avatars");

            migrationBuilder.DropTable(
                name: "HCSTypes");

            migrationBuilder.DropTable(
                name: "TransportRoutes");

            migrationBuilder.DropTable(
                name: "TransportStops");

            migrationBuilder.DropTable(
                name: "TransportCompanies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ActionsMeta");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
