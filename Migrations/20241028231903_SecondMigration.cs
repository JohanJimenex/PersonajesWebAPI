using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonajesWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidads_Personajes_PersonajeId",
                table: "Habilidads");

            migrationBuilder.DropIndex(
                name: "IX_Habilidads_PersonajeId",
                table: "Habilidads");

            migrationBuilder.DropColumn(
                name: "HabilidadId",
                table: "Personajes");

            migrationBuilder.DropColumn(
                name: "PersonajeId",
                table: "Habilidads");

            migrationBuilder.CreateTable(
                name: "HabilidadPersonaje",
                columns: table => new
                {
                    HabilidadesId = table.Column<int>(type: "int", nullable: false),
                    PersonajesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabilidadPersonaje", x => new { x.HabilidadesId, x.PersonajesId });
                    table.ForeignKey(
                        name: "FK_HabilidadPersonaje_Habilidads_HabilidadesId",
                        column: x => x.HabilidadesId,
                        principalTable: "Habilidads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabilidadPersonaje_Personajes_PersonajesId",
                        column: x => x.PersonajesId,
                        principalTable: "Personajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HabilidadPersonaje_PersonajesId",
                table: "HabilidadPersonaje",
                column: "PersonajesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabilidadPersonaje");

            migrationBuilder.AddColumn<int>(
                name: "HabilidadId",
                table: "Personajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonajeId",
                table: "Habilidads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habilidads_PersonajeId",
                table: "Habilidads",
                column: "PersonajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidads_Personajes_PersonajeId",
                table: "Habilidads",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id");
        }
    }
}
