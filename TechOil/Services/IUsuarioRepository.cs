using TechOil.Models;
namespace TechOil.Services
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAllUsuarios();
    }
}
