using API_REST.Models;
using API_REST.Repository;
using API_REST.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoresRepository _autoresRepository;

        public AutoresController(IAutoresRepository autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }


        // GET: api/<AutoresController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Autore> autores = _autoresRepository.GetAll();
            if (!autores.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK, autores);
        }

        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var autor = _autoresRepository.Get(id);
            if (autor == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, autor);
        }

        // POST api/<AutoresController>
        [HttpPost]
        public IActionResult Post([FromBody] Autore autor)
        {
            try
            {
                _autoresRepository.Add(autor);
                return StatusCode(StatusCodes.Status201Created, "Autor creado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");
            }
        }

        // PUT api/<AutoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Autore autor)
        {
            if (id != autor.Id)
            {
                return BadRequest("El ID del autor no coincide con el ID proporcionado.");
            }

            try
            {
                _autoresRepository.Update(autor);
                return StatusCode(StatusCodes.Status202Accepted, "Autor actualizado correctamente.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servicio de autor: {ex.Message}");
            }
        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _autoresRepository.Get(id);
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            try
            {
                _autoresRepository.Delete(usuario);
                return StatusCode(StatusCodes.Status201Created, "Autor eliminada satisfactoriamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");

            }
        }
    }
}
