using API_REST.Models;

namespace API_REST.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria Get(int id);
        void Delete(Categoria categoria);
        void Update(Categoria categoria);
        void Add(Categoria categoria);
    }
}
