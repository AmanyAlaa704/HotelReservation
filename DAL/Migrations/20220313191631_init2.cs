using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessonEnd",
                table: "SeasonTypes",
                newName: "SeasionEnd");

            migrationBuilder.RenameColumn(
                name: "SessonBegin",
                table: "SeasonTypes",
                newName: "SeasionBegin");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "SeasionEnd",
                table: "SeasonTypes",
                newName: "SessonEnd");

            migrationBuilder.RenameColumn(
                name: "SeasionBegin",
                table: "SeasonTypes",
                newName: "SessonBegin");
        }
    }
}
