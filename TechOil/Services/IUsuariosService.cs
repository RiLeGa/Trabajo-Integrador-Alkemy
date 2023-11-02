using TechOil.Models;

namespace TechOil.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByUsername(string username);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }
}
