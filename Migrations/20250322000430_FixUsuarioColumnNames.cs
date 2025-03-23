using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CocinaOcultaAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixUsuarioColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "usuarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "usuarios",
                newName: "rol_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_creacion",
                table: "usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "fecha_creacion",
                table: "usuarios");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "rol_id",
                table: "Usuarios",
                newName: "RolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
