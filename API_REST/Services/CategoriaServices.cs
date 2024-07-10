using API_REST.Models;
using API_REST.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class CategoriaServices : ICategoryRepository
    {
        private readonly BibliotecaContext _context;
        private readonly ILogger<CategoriaServices> _logger;
        private readonly IValidator<Categoria> _validator;

        public CategoriaServices(BibliotecaContext context, ILogger<CategoriaServices> logger, IValidator<Categoria> validator)
        {
            _context = context;
            _logger = logger;
            _validator = validator;
        }

        public void Add(Categoria categoria)
        {
            //validar el usuario 
            var validationResult = _validator.Validate(categoria);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de categorias: {ex.Message}");
            }
        }

        public void Delete(Categoria categoria)
        {
            try
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de categorias: {ex.Message}");
            }
        }

        public Categoria Get(int id)
        {
            try
            {
                var categoria = _context.Categorias.Find(id);
                return categoria;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de categorias: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                var categorias = _context.Categorias.ToList();
                return categorias;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de categorias: {ex.Message}");
                throw;
            }
        }

        public void Update(Categoria categoria)
        {
            var validationResult = _validator.Validate(categoria);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de categorias: {ex.Message}");
                throw;
            }
        }
    }
}
