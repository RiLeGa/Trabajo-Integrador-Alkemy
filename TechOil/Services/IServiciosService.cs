using TechOil.Models;

namespace TechOil.Services
{
    public interface IProyectosService
    {
        IEnumerable<Proyecto> GetAll();
        public Proyecto GetById(int id);
        void Add(Proyecto proyecto);
        void Update(Proyecto proyecto);
        void Delete(int id);
    }
}
