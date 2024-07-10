using API_REST.DTOs;
using API_REST.Models;

namespace API_REST.Repository
{
    public interface ILibroRepository
    {
        IEnumerable<Libro> GetAll();
        IEnumerable<Libro> GetAllByAuthor(int id);
        IEnumerable<Libro> GetAllByCategory(int id);
        Libro Get(int id);
        void Delete(Libro libro);
        void Update(LibroCreateDTO libro);
        void Add(LibroCreateDTO libroDto);
    }
}
