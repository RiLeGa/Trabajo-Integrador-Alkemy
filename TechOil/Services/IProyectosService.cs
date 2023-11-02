using TechOil.Models;

namespace TechOil.Services
{
    public interface IProyectosService
    {
        Task<IEnumerable<Proyecto>> GetAll();
        Task<Proyecto> GetById(int id);
        Task Add(Proyecto proyecto);
        Task Update(Proyecto proyecto);
        Task Delete(int id);
    }
}
