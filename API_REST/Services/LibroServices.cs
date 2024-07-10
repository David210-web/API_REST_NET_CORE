using API_REST.DTOs;
using API_REST.Models;
using API_REST.Repository;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class LibroServices : ILibroRepository
    {
        private readonly BibliotecaContext _context;
        private readonly ILogger<LibroServices> _logger;
        private readonly IValidator<LibroCreateDTO> _dtovalidator;
        private readonly IMapper _mapper;

        public LibroServices(BibliotecaContext context, ILogger<LibroServices> logger, IValidator<LibroCreateDTO> validator,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _dtovalidator = validator;
            _mapper = mapper;
        }

        public void Add(LibroCreateDTO libroDtop)
        {
            var validationResult = _dtovalidator.Validate(libroDtop);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var libro = _mapper.Map<Libro>(libroDtop);
            try
            {
                _context.Libros.Add(libro);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de libros: {ex.Message}");
            }
        }

        public void Delete(Libro libro)
        {
            try
            {
                _context.Libros.Remove(libro);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de libro: {ex.Message}");
            }
        }

        public Libro Get(int id)
        {
            try
            {
                var libro = _context.Libros.Find(id);
                return libro;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de libros: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Libro> GetAll()
        {
            try
            {
                var libros = _context.Libros.ToList();
                return libros;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de libros: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Libro> GetAllByAuthor(int id)
        {
            try
            {
                var libros = from libro in _context.Libros where libro.AutorId == id select libro;
                return libros;
            }catch(DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }catch(Exception ex)
            {
                _logger.LogError($"Error en el servicio de libros");
                throw;
            }
        }

        public IEnumerable<Libro> GetAllByCategory(int id)
        {
            try
            {
                var libros = from libro in _context.Libros where libro.CategoriaId == id select libro;
                return libros;
            }catch(DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos {ex.Message}");
                throw;
            }catch(Exception ex)
            {
                _logger.LogError("Error en el servicio de libros");
                throw;
            }
        }

        public void Update(LibroCreateDTO libroDto)
        {
            var validationResult = _dtovalidator.Validate(libroDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var libro = _mapper.Map<Libro>(libroDto);
            try
            {
                _context.Libros.Update(libro);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de libros: {ex.Message}");
                throw;
            }
        }
    }
}
