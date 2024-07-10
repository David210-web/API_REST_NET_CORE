using API_REST.DTOs;
using API_REST.Models;

namespace API_REST.Repository
{
    public interface IPrestamoRepository
    {
        IEnumerable<Prestamo> GetAll();
        Prestamo Get(int id);
        void Delete(Prestamo prestamo);
        void Update(PrestamoCreateDTO prestamo);
        void Add(PrestamoCreateDTO prestamo);
    }
}
