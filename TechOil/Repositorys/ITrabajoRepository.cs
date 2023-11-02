using TechOil.Models;
namespace TechOil.Repositorys

{
    public interface ITrabajoRepository
    {
        Task<IEnumerable<Trabajo>> GetAllTrabajos();
        Task<Trabajo> GetTrabajoById(int id);
        Task AddTrabajo(Trabajo trabajo);
        Task UpdateTrabajo(Trabajo trabajo);
        Task DeleteTrabajo(int id);
    }
}
