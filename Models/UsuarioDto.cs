namespace CocinaOcultaAPI.Models
{
    public class UsuarioDto
    {
        public int Id { get; set; }
	public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string Rol { get; set; } = string.Empty;
    }
}
