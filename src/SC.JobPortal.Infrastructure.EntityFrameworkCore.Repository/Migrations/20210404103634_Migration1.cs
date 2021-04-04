using Microsoft.EntityFrameworkCore.Migrations;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, ".Net Core Developer" },
                    { 2, "Python Developer" },
                    { 3, "Database Administrator" },
                    { 4, "SQL Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
