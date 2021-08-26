using Microsoft.EntityFrameworkCore.Migrations;

namespace Tsi.Template.Data.Migrations
{
    public partial class AddTiersEntity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Tiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComplementAdresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SecteursActivitesId = table.Column<int>(type: "int", nullable: false),
                    NatureParDefaut = table.Column<int>(type: "int", nullable: false),
                    NatureId = table.Column<int>(type: "int", nullable: true),
                    PaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Tiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Tiers_App_Natures_NatureId",
                        column: x => x.NatureId,
                        principalTable: "App_Natures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_App_Tiers_App_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "App_Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_App_Tiers_App_SecteursActivites_SecteursActivitesId",
                        column: x => x.SecteursActivitesId,
                        principalTable: "App_SecteursActivites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_Tiers_NatureId",
                table: "App_Tiers",
                column: "NatureId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Tiers_PaysId",
                table: "App_Tiers",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Tiers_SecteursActivitesId",
                table: "App_Tiers",
                column: "SecteursActivitesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Tiers");
        }
    }
}
