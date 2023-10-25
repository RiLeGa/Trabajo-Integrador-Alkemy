
using TechOil.DataAccess;
using TechOil.Models;

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
        public Proyecto GetProyectoById(int id)
        {
            return _dbContext.Proyectos.FirstOrDefault(p => p.CodProyecto == id);
        }
        public void AddProyecto(Proyecto proyecto) 
        {
            _dbContext.Proyectos.Add(proyecto);
            _dbContext.SaveChanges();
        } 
        public void UpdateProyecto(Proyecto proyecto) 
        {
            _dbContext.Proyectos.Update(proyecto);
            _dbContext.SaveChanges();
        }
        public void DeleteProyecto(int id) 
        {
            var proyecto = _dbContext.Proyectos.FirstOrDefault(p => p.CodProyecto == id);
            if (proyecto != null) 
            {
                _dbContext.Proyectos.Remove(proyecto);
                _dbContext.SaveChanges();
            }
        } 
     
    }
}
