using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveLearningFramework.Migrations
{
    public partial class submodulechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubModuleId",
                table: "SubModules",
                newName: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModules_ModuleId",
                table: "SubModules",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubModules_Modules_ModuleId",
                table: "SubModules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubModules_Modules_ModuleId",
                table: "SubModules");

            migrationBuilder.DropIndex(
                name: "IX_SubModules_ModuleId",
                table: "SubModules");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "SubModules",
                newName: "SubModuleId");
        }
    }
}
