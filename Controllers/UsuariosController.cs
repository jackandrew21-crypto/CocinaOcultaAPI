using CocinaOcultaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CocinaOcultaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .Select(u => new UsuarioDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Cedula = u.Cedula,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Direccion = u.Direccion,
                    Cargo = u.Cargo,
                    Activo = u.Activo,
                    Rol = u.Rol != null ? u.Rol.Nombre : ""
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: api/Usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario updatedUsuario)
        {
            if (id != updatedUsuario.Id)
                return BadRequest(new { mensaje = "El ID proporcionado no coincide." });

            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
                return NotFound(new { mensaje = "Usuario no encontrado" });

            // Actualizar campos
            usuarioExistente.Nombre = updatedUsuario.Nombre;
            usuarioExistente.Apellidos = updatedUsuario.Apellidos;
            usuarioExistente.Cedula = updatedUsuario.Cedula;
            usuarioExistente.Email = updatedUsuario.Email;
            usuarioExistente.Telefono = updatedUsuario.Telefono;
            usuarioExistente.Direccion = updatedUsuario.Direccion;
            usuarioExistente.Cargo = updatedUsuario.Cargo;
            usuarioExistente.RolId = updatedUsuario.RolId;
            usuarioExistente.Activo = updatedUsuario.Activo;

            // Solo actualizar contraseña si se proporciona
            if (!string.IsNullOrWhiteSpace(updatedUsuario.Password))
            {
                usuarioExistente.Password = updatedUsuario.Password;
            }

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(e => e.Id == id))
                    return NotFound(new { mensaje = "Usuario ya no existe." });

                throw;
            }
        }

        // PATCH: api/Usuarios/{id}/activar
        [HttpPatch("{id}/activar")]
        public async Task<IActionResult> ActivarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Activo = true;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario activado correctamente" });
        }

        // PATCH: api/Usuarios/{id}/desactivar
        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> DesactivarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            usuario.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario desactivado correctamente" });
        }
    }
}
