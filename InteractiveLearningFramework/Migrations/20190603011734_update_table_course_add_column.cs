using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningFramework.Migrations
{
    public partial class update_table_course_add_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Course",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Course",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");
        }
    }
}
