using TechOil.Models;
namespace TechOil.Services

{
    public interface ITrabajoRepository
    {
        IEnumerable<Trabajo> GetAllTrabajos();
    }
}
