using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_SeasonTypes_SeasonId",
                table: "MealPlans");

            migrationBuilder.DropIndex(
                name: "IX_MealPlans_SeasonId",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "MealPlans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "MealPlans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "MealPlans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_SeasonId",
                table: "MealPlans",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_SeasonTypes_SeasonId",
                table: "MealPlans",
                column: "SeasonId",
                principalTable: "SeasonTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
