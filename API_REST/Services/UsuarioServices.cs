using API_REST.Models;
using API_REST.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace API_REST.Services
{
    public class UsuarioServices : IUsuarioRepository
    {
        private readonly BibliotecaContext _context;
        private readonly ILogger<UsuarioServices> _logger; 
        private readonly IValidator<Usuario> _validator;
        public UsuarioServices(BibliotecaContext context,ILogger<UsuarioServices> logger,IValidator<Usuario> validator)
        {
            _context = context;
            _logger = logger;
            _validator = validator;
        }

        public void Add(Usuario usuario)
        {
            //validar el usuario 
            var validationResult = _validator.Validate(usuario);
            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

            }catch(DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }catch(Exception ex)
            {
                _logger.LogError($"Error en el servicio de usuarios: {ex.Message}");
            }
        }

        public void Delete(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de usuarios: {ex.Message}");
            }
        }

        public Usuario Get(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                return usuario;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de usuarios: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList();
                return usuarios;
            }catch(DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error en el servicio de usuarios: {ex.Message}");
                throw;
            }
        }

        public void Update(Usuario usuario)
        {
            var validationResult = _validator.Validate(usuario);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            try
            {
                 _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Error al actualizar la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en el servicio de usuarios: {ex.Message}");
                throw;
            }
        }
    }
}
