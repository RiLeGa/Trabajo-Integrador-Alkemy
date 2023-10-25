using TechOil.Models;
namespace TechOil.Repositorys
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAllUsuarios();
        public Usuario GetUsuarioById(int id);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int id);

        public Usuario GetUserByUsername(string username);
    }
}
