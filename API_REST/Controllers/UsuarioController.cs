using API_REST.Models;
using API_REST.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuario;
        public UsuarioController(IUsuarioRepository usuario)
        {
            _usuario = usuario;
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Usuario> usuarios = _usuario.GetAll();
            if(!usuarios.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK,usuarios);

        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuario.Get(id);
            if(usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                _usuario.Add(usuario);
                return StatusCode(StatusCodes.Status201Created,"Usuario creado satisfactoriamente");
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,$"Hay un error {ex.Message}");
            }

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("El ID del usuario no coincide con el ID proporcionado.");
            }

            try
            {
                _usuario.Update(usuario);
                return StatusCode(StatusCodes.Status202Accepted,"Usuario actualizado correctamente.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servicio de usuarios: {ex.Message}");
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _usuario.Get(id);
            if(usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            try
            {
                _usuario.Delete(usuario);
                return StatusCode(StatusCodes.Status201Created, "Usuario eliminado satisfactoriamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,$"Hay un error {ex.Message}");

            }
        }
    }
}
