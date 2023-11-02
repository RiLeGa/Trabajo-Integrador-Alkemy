using TechOil.Models;

namespace TechOil.Services
{
    public interface ITrabajosService
    {
        Task<IEnumerable<Trabajo>> GetAll();
        Task<Trabajo> GetById(int id);
        Task Add(Trabajo trabajo);
        Task Update(Trabajo trabajo);
        Task Delete(int id);
    }
}
