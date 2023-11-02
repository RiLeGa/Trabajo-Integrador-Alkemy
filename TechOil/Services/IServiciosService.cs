using TechOil.Models;

namespace TechOil.Services
{
    public interface IServiciosService
    {
        Task<IEnumerable<Servicio>> GetAll();
        Task<Servicio> GetById(int id);
        Task Add(Servicio servicio);
        Task Update(Servicio servicio);
        Task Delete(int id);
    }
}
