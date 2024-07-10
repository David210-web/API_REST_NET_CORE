using API_REST.DTOs;
using API_REST.Models;
using API_REST.Repository;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class PrestamosServices : IPrestamoRepository
    {
        private readonly BibliotecaContext _context;
        private readonly ILogger<PrestamosServices> _logger;
        private readonly IValidator<PrestamoCreateDTO> _validator;
        private readonly IMapper _mapper;

        public PrestamosServices(BibliotecaContext context, ILogger<PrestamosServices> logger, IValidator<PrestamoCreateDTO> validator,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _validator = validator;
            _mapper = mapper;
        }

        public void Add(PrestamoCreateDTO prestamoDTO)
        {
            //validar el usuario 
            var validationResult = _validator.Validate(prestamoDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var prestamo = _mapper.Map<Prestamo>(prestamoDTO);
            try
            {
                _context.Prestamos.Add(prestamo);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de prestamos: {ex.Message}");
            }
        }

        public void Delete(Prestamo prestamo)
        {
            try
            {
                _context.Prestamos.Remove(prestamo);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de prestamos: {ex.Message}");
            }
        }

        public Prestamo Get(int id)
        {
            try
            {
                var prestamos = _context.Prestamos.Find(id);
                return prestamos;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de prestamos: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Prestamo> GetAll()
        {
            try
            {
                var prestamos = _context.Prestamos.ToList();
                return prestamos;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de prestamos: {ex.Message}");
                throw;
            }
        }

        public void Update(PrestamoCreateDTO prestamoDTO)
        {
            var validationResult = _validator.Validate(prestamoDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var prestamo = _mapper.Map<Prestamo>(prestamoDTO);
            try
            {
                _context.Prestamos.Update(prestamo);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de prestamos: {ex.Message}");
                throw;
            }
        }
    }
}
