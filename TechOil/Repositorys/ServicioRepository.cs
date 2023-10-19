using TechOil.DataAccess;
using TechOil.Models;
using TechOil.Services;

namespace TechOil.Repositorys
{
    public class ServicioRepository : IServicioRepository
    {
        public readonly TechOilDbContext _dbContext;

        public ServicioRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            return _dbContext.Servicios.ToList();
        }
        public Servicio GetServicioById(int id)
        {
            return _dbContext.Servicios.FirstOrDefault(p => p.CodServicio == id);
        }
        public void AddServicio(Servicio Servicio) 
        {
            _dbContext.Servicios.Add(Servicio);
            _dbContext.SaveChanges();
        } 
        public void UpdateServicio(Servicio Servicio) 
        {
            _dbContext.Servicios.Update(Servicio);
            _dbContext.SaveChanges();
        }
        public void DeleteServicio(int id) 
        {
            var Servicio = _dbContext.Servicios.FirstOrDefault(p => p.CodServicio == id);
            if (Servicio != null) 
            {
                _dbContext.Servicios.Remove(Servicio);
                _dbContext.SaveChanges();
            }
        } 
    }
}
