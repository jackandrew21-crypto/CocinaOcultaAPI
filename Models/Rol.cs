using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocinaOcultaAPI.Models
{
    [Table("roles")] // <- Esto es lo importante
    public class Rol
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}
