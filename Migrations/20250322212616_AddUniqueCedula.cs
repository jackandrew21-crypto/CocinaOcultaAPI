using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CocinaOcultaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_Rol_rol_id",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "roles",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "apellidos",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cargo",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cedula",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_cedula",
                table: "usuarios",
                column: "cedula",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_rol_id",
                table: "usuarios",
                column: "rol_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_rol_id",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_cedula",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "apellidos",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "cargo",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "cedula",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "direccion",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Rol",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rol",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_Rol_rol_id",
                table: "usuarios",
                column: "rol_id",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
