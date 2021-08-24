using Microsoft.EntityFrameworkCore.Migrations;

namespace Tsi.Template.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpertComptableId",
                table: "App_Pays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpertComptableId",
                table: "App_Pays");
        }
    }
}
