using TechOil.Models;

namespace TechOil.Services
{
    public interface IUsuariosService
    {
        IEnumerable<Usuario> GetAll();
        public Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);

        public Usuario GetByUsername(string username);
    }
}
