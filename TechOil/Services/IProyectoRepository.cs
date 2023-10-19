using TechOil.Models;
namespace TechOil.Services
{
    public interface IProyectoRepository
    {
        IEnumerable<Proyecto> GetAllProyectos();
        public  Proyecto GetProyectoById(int id);
        void AddProyecto(Proyecto proyecto);
        void UpdateProyecto(Proyecto proyecto);
        void DeleteProyecto(int id);
    }
}
