using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tsi.Template.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_ModePayements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodeSurDeclarationTVA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ModePayements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Natures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodeSurDeclaration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Natures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SymboleMonetaire = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NbreDecimales = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_SecteursActivites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_SecteursActivites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageCulture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UniqueSeoCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FlagImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rtl = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogLevelId = table.Column<int>(type: "int", nullable: false),
                    ShortMessage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FullMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    PageUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ReferrerUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SystemName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Common_UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_ExpertComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaysId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ComplementAdresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_ExpertComptables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_ExpertComptables_App_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "App_Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Common_Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Common_Translations_Common_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Common_Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Common_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUsername = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LockedOut = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FailedAttempts = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastIpAdress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Common_Users_Common_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Common_Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Common_PermissionUserRoleMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_PermissionUserRoleMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Common_PermissionUserRoleMappings_Common_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Common_Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Common_PermissionUserRoleMappings_Common_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Common_UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "App_Societes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdentifiantFiscal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpertComptableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Societes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_App_Societes_App_ExpertComptables_ExpertComptableId",
                        column: x => x.ExpertComptableId,
                        principalTable: "App_ExpertComptables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Common_UserPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_UserPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Common_UserPasswords_Common_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Common_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Common_UserRoleMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Common_UserRoleMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Common_UserRoleMappings_Common_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "Common_UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Common_UserRoleMappings_Common_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Common_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_App_ExpertComptables_Code",
                table: "App_ExpertComptables",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ExpertComptables_Nom",
                table: "App_ExpertComptables",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ExpertComptables_PaysId",
                table: "App_ExpertComptables",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_App_ModePayements_Code",
                table: "App_ModePayements",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_ModePayements_Nom",
                table: "App_ModePayements",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Natures_Code",
                table: "App_Natures",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Natures_Nom",
                table: "App_Natures",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Pays_Code",
                table: "App_Pays",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Pays_Nom",
                table: "App_Pays",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Pays_SymboleMonetaire",
                table: "App_Pays",
                column: "SymboleMonetaire",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_SecteursActivites_Code",
                table: "App_SecteursActivites",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_SecteursActivites_Nom",
                table: "App_SecteursActivites",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Societes_Code",
                table: "App_Societes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_App_Societes_ExpertComptableId",
                table: "App_Societes",
                column: "ExpertComptableId");

            migrationBuilder.CreateIndex(
                name: "IX_App_Societes_IdentifiantFiscal",
                table: "App_Societes",
                column: "IdentifiantFiscal",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Common_Permissions_SystemName",
                table: "Common_Permissions",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Common_PermissionUserRoleMappings_PermissionId",
                table: "Common_PermissionUserRoleMappings",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_PermissionUserRoleMappings_UserRoleId",
                table: "Common_PermissionUserRoleMappings",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Translations_Key_LanguageId",
                table: "Common_Translations",
                columns: new[] { "Key", "LanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Common_Translations_LanguageId",
                table: "Common_Translations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_UserPasswords_UserId",
                table: "Common_UserPasswords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_UserRoleMappings_UserId",
                table: "Common_UserRoleMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_UserRoleMappings_UserRoleId",
                table: "Common_UserRoleMappings",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_UserRoles_SystemName",
                table: "Common_UserRoles",
                column: "SystemName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_Email",
                table: "Common_Users",
                column: "Email",
                unique: true,
                filter: " Email IS NOT NULL ");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_LanguageId",
                table: "Common_Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_NormalizedEmail",
                table: "Common_Users",
                column: "NormalizedEmail",
                unique: true,
                filter: " NormalizedEmail IS NOT NULL ");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_NormalizedUsername",
                table: "Common_Users",
                column: "NormalizedUsername",
                unique: true,
                filter: " NormalizedUsername IS NOT NULL ");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_PhoneNumber",
                table: "Common_Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Common_Users_Username",
                table: "Common_Users",
                column: "Username",
                unique: true,
                filter: " Username IS NOT NULL ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_ModePayements");

            migrationBuilder.DropTable(
                name: "App_Natures");

            migrationBuilder.DropTable(
                name: "App_SecteursActivites");

            migrationBuilder.DropTable(
                name: "App_Societes");

            migrationBuilder.DropTable(
                name: "Common_Logs");

            migrationBuilder.DropTable(
                name: "Common_PermissionUserRoleMappings");

            migrationBuilder.DropTable(
                name: "Common_Settings");

            migrationBuilder.DropTable(
                name: "Common_Translations");

            migrationBuilder.DropTable(
                name: "Common_UserPasswords");

            migrationBuilder.DropTable(
                name: "Common_UserRoleMappings");

            migrationBuilder.DropTable(
                name: "App_ExpertComptables");

            migrationBuilder.DropTable(
                name: "Common_Permissions");

            migrationBuilder.DropTable(
                name: "Common_UserRoles");

            migrationBuilder.DropTable(
                name: "Common_Users");

            migrationBuilder.DropTable(
                name: "App_Pays");

            migrationBuilder.DropTable(
                name: "Common_Languages");
        }
    }
}
