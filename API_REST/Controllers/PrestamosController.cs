using API_REST.DTOs;
using API_REST.Models;
using API_REST.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoRepository _prestamoRepository;

        public PrestamosController(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }


        // GET: api/<PrestamosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Prestamo> prestamos = _prestamoRepository.GetAll();
            if (!prestamos.Any())
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay datos");
            }
            return StatusCode(StatusCodes.Status200OK, prestamos);
        }

        // GET api/<PrestamosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prestamo = _prestamoRepository.Get(id);
            if (prestamo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            return StatusCode(StatusCodes.Status200OK, prestamo);
        }

        // POST api/<PrestamosController>
        [HttpPost]
        public IActionResult Post([FromBody] PrestamoCreateDTO prestamoCreateDTO)
        {
            try
            {
                _prestamoRepository.Add(prestamoCreateDTO);
                return StatusCode(StatusCodes.Status201Created, "Prestamo creado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");
            }
        }

        // PUT api/<PrestamosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PrestamoCreateDTO prestamoCreateDTO)
        {
            if (id != prestamoCreateDTO.Id)
            {
                return BadRequest("El ID de la categoria no coincide con el ID proporcionado.");
            }

            try
            {
                _prestamoRepository.Update(prestamoCreateDTO);
                return StatusCode(StatusCodes.Status202Accepted, "Prestamo actualizado correctamente.");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servicio de prestamo: {ex.Message}");
            }
        }

        // DELETE api/<PrestamosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prestamo = _prestamoRepository.Get(id);
            if (prestamo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No hay dato con ese ID");
            }
            try
            {
                _prestamoRepository.Delete(prestamo);
                return StatusCode(StatusCodes.Status201Created, "Prestamo eliminada satisfactoriamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Hay un error {ex.Message}");

            }
        }
    }
}
