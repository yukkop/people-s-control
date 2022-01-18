using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataBase.Migrations
{
    public partial class TransportRouteNumberbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_Categorie~",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_MyPropertyId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_TaskTypes_TaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_CategorieOfPro~",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_TransportCompanies_ManagementCompanieId",
                table: "TransportStops");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_TransportStops_ManagementCompanieId",
                table: "TransportStops");

            migrationBuilder.DropIndex(
                name: "IX_ReportsByProblemCategories_CategorieOfProblemId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropIndex(
                name: "IX_HCSTasks_TaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropIndex(
                name: "IX_HCSsByProblemCategories_MyPropertyId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropIndex(
                name: "IX_DraftReportsByProblemCategories_CategorieOfProblemId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "ManagementCompanieId",
                table: "TransportStops");

            migrationBuilder.DropColumn(
                name: "CategorieOfProblemId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropColumn(
                name: "MyPropertyId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "CategorieOfProblemId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "TransportRoutes",
                newName: "Number");

            migrationBuilder.AddColumn<long>(
                name: "TransportCompanyId",
                table: "TransportStops",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "TransportRoutes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "ProblemCategoryId",
                table: "ReportsByProblemCategories",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HCSTaskTypeId",
                table: "HCSTasks",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProblemCategoryId",
                table: "HCSsByProblemCategories",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProblemCategoryId",
                table: "DraftReportsByProblemCategories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HCSTaskTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HCSTaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_TransportCompanyId",
                table: "TransportStops",
                column: "TransportCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsByProblemCategories_ProblemCategoryId",
                table: "ReportsByProblemCategories",
                column: "ProblemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_HCSTaskTypeId",
                table: "HCSTasks",
                column: "HCSTaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories",
                column: "ProblemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReportsByProblemCategories_ProblemCategoryId",
                table: "DraftReportsByProblemCategories",
                column: "ProblemCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories",
                column: "ProblemCategoryId",
                principalTable: "ProblemCategories",
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
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks",
                column: "HCSTaskTypeId",
                principalTable: "HCSTaskTypes",
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
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops",
                column: "TransportCompanyId",
                principalTable: "TransportCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_ProblemCa~",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_HCSTasks_HCSTaskTypes_HCSTaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_ProblemCategor~",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportStops_TransportCompanies_TransportCompanyId",
                table: "TransportStops");

            migrationBuilder.DropTable(
                name: "HCSTaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_TransportStops_TransportCompanyId",
                table: "TransportStops");

            migrationBuilder.DropIndex(
                name: "IX_ReportsByProblemCategories_ProblemCategoryId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropIndex(
                name: "IX_HCSTasks_HCSTaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropIndex(
                name: "IX_HCSsByProblemCategories_ProblemCategoryId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropIndex(
                name: "IX_DraftReportsByProblemCategories_ProblemCategoryId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "TransportCompanyId",
                table: "TransportStops");

            migrationBuilder.DropColumn(
                name: "ProblemCategoryId",
                table: "ReportsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "HCSTaskTypeId",
                table: "HCSTasks");

            migrationBuilder.DropColumn(
                name: "ProblemCategoryId",
                table: "HCSsByProblemCategories");

            migrationBuilder.DropColumn(
                name: "ProblemCategoryId",
                table: "DraftReportsByProblemCategories");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "TransportRoutes",
                newName: "number");

            migrationBuilder.AddColumn<long>(
                name: "ManagementCompanieId",
                table: "TransportStops",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "number",
                table: "TransportRoutes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategorieOfProblemId",
                table: "ReportsByProblemCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TaskTypeId",
                table: "HCSTasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MyPropertyId",
                table: "HCSsByProblemCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategorieOfProblemId",
                table: "DraftReportsByProblemCategories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportStops_ManagementCompanieId",
                table: "TransportStops",
                column: "ManagementCompanieId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsByProblemCategories_CategorieOfProblemId",
                table: "ReportsByProblemCategories",
                column: "CategorieOfProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSTasks_TaskTypeId",
                table: "HCSTasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HCSsByProblemCategories_MyPropertyId",
                table: "HCSsByProblemCategories",
                column: "MyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftReportsByProblemCategories_CategorieOfProblemId",
                table: "DraftReportsByProblemCategories",
                column: "CategorieOfProblemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftReportsByProblemCategories_ProblemCategories_Categorie~",
                table: "DraftReportsByProblemCategories",
                column: "CategorieOfProblemId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSsByProblemCategories_ProblemCategories_MyPropertyId",
                table: "HCSsByProblemCategories",
                column: "MyPropertyId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HCSTasks_TaskTypes_TaskTypeId",
                table: "HCSTasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportsByProblemCategories_ProblemCategories_CategorieOfPro~",
                table: "ReportsByProblemCategories",
                column: "CategorieOfProblemId",
                principalTable: "ProblemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportStops_TransportCompanies_ManagementCompanieId",
                table: "TransportStops",
                column: "ManagementCompanieId",
                principalTable: "TransportCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
