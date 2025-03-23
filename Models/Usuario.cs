using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocinaOcultaAPI.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Column("cedula")]
        public string Cedula { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [Column("direccion")]
        public string Direccion { get; set; } = string.Empty;

        [Column("cargo")]
        public string Cargo { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [Column("activo")]
        public bool Activo { get; set; }

        // ✅ Solo una definición de RolId
        [Column("rol_id")]
        public int RolId { get; set; }

        // Relación con tabla roles
        public Rol? Rol { get; set; }
    }
}

