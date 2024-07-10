using API_REST.Models;
using API_REST.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriaController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Categoria> categoria = _categoryRepository.GetAll();
            if (!categoria.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK, categoria);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var categoria = _categoryRepository.Get(id);
            if (categoria == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, categoria);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _categoryRepository.Add(categoria);
                return StatusCode(StatusCodes.Status201Created, "Categoria creada satisfactoriamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest("El ID de la categoria no coincide con el ID proporcionado.");
            }

            try
            {
                _categoryRepository.Update(categoria);
                return StatusCode(StatusCodes.Status202Accepted, "Categoria actualizado correctamente.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servicio de categorias: {ex.Message}");
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _categoryRepository.Get(id);
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            try
            {
                _categoryRepository.Delete(usuario);
                return StatusCode(StatusCodes.Status201Created, "Categoria eliminada satisfactoriamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");

            }
        }
    }
}
