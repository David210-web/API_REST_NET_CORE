using API_REST.DTOs;
using API_REST.Models;
using API_REST.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMapper _mapper;

        public LibrosController(ILibroRepository libroRepository,IMapper mapper)
        {
            _mapper = mapper;
            _libroRepository = libroRepository;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Libro> libros = _libroRepository.GetAll();
            if (!libros.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK, libros);
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var libro = _libroRepository.Get(id);
            if (libro == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, libro);
        }

        // GET api/<LibrosController/categoria/5
        [HttpGet("categoria/{id}")]
        public IActionResult GetByCategory(int id)
        {
            var libros = _libroRepository.GetAllByCategory(id);
            if (libros == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, libros);
        }

        // GET api/<LibrosController/autor/5
        [HttpGet("autor/{id}")]
        public IActionResult GetByAuthor(int id)
        {
            var libros = _libroRepository.GetAllByAuthor(id);
            if (libros == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, libros);
        }

        // POST api/<LibrosController>
        [HttpPost]
        public IActionResult Post([FromBody] LibroCreateDTO libroDto)
        {
            try
            {
                
                _libroRepository.Add(libroDto);
                return StatusCode(StatusCodes.Status201Created, "Libro creado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");
            }
        }

        // PUT api/<LibrosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LibroCreateDTO libroDTO)
        {
            if (id != libroDTO.Id)
            {
                return BadRequest("El ID de la categoria no coincide con el ID proporcionado.");
            }

            try
            {
                _libroRepository.Update(libroDTO);
                return StatusCode(StatusCodes.Status202Accepted, "Libro actualizado correctamente.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servicio de libro: {ex.Message}");
            }
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _libroRepository.Get(id);
            if (usuario == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            try
            {
                _libroRepository.Delete(usuario);
                return StatusCode(StatusCodes.Status201Created, "Categoria eliminada satisfactoriamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");

            }
        }
    }
}
