
using TechOil.DataAccess;
using TechOil.Models;
using TechOil.Services;

namespace TechOil.Repositorys
{
    public class ProyectoRepository : IProyectoRepository
    {
        public readonly TechOilDbContext _dbContext;

        public ProyectoRepository(TechOilDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Proyecto> GetAllProyectos()
        {
            return _dbContext.Proyectos.ToList();
        }
    }
}
