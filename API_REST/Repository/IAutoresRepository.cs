using API_REST.Models;

namespace API_REST.Repository
{
    public interface IAutoresRepository
    {
        IEnumerable<Autore> GetAll();
        Autore Get(int id);
        void Delete(Autore autor);
        void Update(Autore autor);
        void Add(Autore autor);
    }
}
