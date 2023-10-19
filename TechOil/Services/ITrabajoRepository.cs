using TechOil.Models;
namespace TechOil.Services

{
    public interface ITrabajoRepository
    {
        IEnumerable<Trabajo> GetAllTrabajos();
        public Trabajo GetTrabajoById(int id);
        void AddTrabajo(Trabajo trabajo);
        void UpdateTrabajo(Trabajo trabajo);
        void DeleteTrabajo(int id);
    }
}
