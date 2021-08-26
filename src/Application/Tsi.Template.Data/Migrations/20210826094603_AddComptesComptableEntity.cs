using Microsoft.EntityFrameworkCore.Migrations;

namespace Tsi.Template.Data.Migrations
{
    public partial class AddComptesComptableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_ComptesComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NatureCompteComptable = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SocieteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ComptesComptables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_ComptesComptables_App_Societes_SocieteId",
                        column: x => x.SocieteId,
                        principalTable: "App_Societes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_ComptesComptables_SocieteId_Intitule",
                table: "App_ComptesComptables",
                columns: new[] { "SocieteId", "Intitule" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ComptesComptables_SocieteId_Numero",
                table: "App_ComptesComptables",
                columns: new[] { "SocieteId", "Numero" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_ComptesComptables");
        }
    }
}
