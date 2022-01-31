using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class DraftReportRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DraftReports");

            migrationBuilder.AddColumn<string>(
                name: "ProblemDescription",
                table: "DraftReports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemDescription",
                table: "DraftReports");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DraftReports",
                type: "text",
                nullable: true);
        }
    }
}
