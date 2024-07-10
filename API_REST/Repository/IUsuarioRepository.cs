using API_REST.Models;

namespace API_REST.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario Get(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
