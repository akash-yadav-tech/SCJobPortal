using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "JobApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
