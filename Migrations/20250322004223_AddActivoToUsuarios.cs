using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CocinaOcultaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddActivoToUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "activo",
                table: "usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rol_id",
                table: "usuarios",
                column: "rol_id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_Rol_rol_id",
                table: "usuarios",
                column: "rol_id",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_Rol_rol_id",
                table: "usuarios");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_rol_id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "activo",
                table: "usuarios");
        }
    }
}
