using TechOil.Models;
namespace TechOil.Services
{
    public interface IProyectoRepository
    {
        IEnumerable<Proyecto> GetAllProyectos();
    }
}
