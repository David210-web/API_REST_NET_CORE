using API_REST.Models;
using API_REST.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class AutoresServices : IAutoresRepository
    {
        private readonly BibliotecaContext _context;
        private readonly ILogger<CategoriaServices> _logger;
        private readonly IValidator<Autore> _validator;

        public AutoresServices(BibliotecaContext context, ILogger<CategoriaServices> logger, IValidator<Autore> validator)
        {
            _context = context;
            _logger = logger;
            _validator = validator;
        }

        public void Add(Autore autor)
        {
            //validar el usuario 
            var validationResult = _validator.Validate(autor);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de autores: {ex.Message}");
            }
        }

        public void Delete(Autore autor)
        {
            try
            {
                _context.Autores.Remove(autor);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de autores: {ex.Message}");
            }
        }

        public Autore Get(int id)
        {
            try
            {
                var autores = _context.Autores.Find(id);
                return autores;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de autores: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Autore> GetAll()
        {
            try
            {
                var autores = _context.Autores.ToList();
                return autores;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de autores: {ex.Message}");
                throw;
            }
        }

        public void Update(Autore autor)
        {
            var validationResult = _validator.Validate(autor);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                _context.Autores.Update(autor);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de autores: {ex.Message}");
                throw;
            }
        }
    }
}
