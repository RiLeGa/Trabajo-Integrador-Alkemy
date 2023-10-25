using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repositorys
{
    public class TrabajoRepository : ITrabajoRepository
    {
        public readonly TechOilDbContext _dbContext;

        public TrabajoRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Trabajo> GetAllTrabajos()
        {
            return _dbContext.Trabajos.ToList();
        }
        public Trabajo GetTrabajoById(int id)
        {
            return _dbContext.Trabajos.FirstOrDefault(p => p.CodTrabajo == id);
        }
        public void AddTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            _dbContext.SaveChanges();
        }
        public void UpdateTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Update(trabajo);
            _dbContext.SaveChanges();
        }
        public void DeleteTrabajo(int id)
        {
            var trabajo = _dbContext.Trabajos.FirstOrDefault(p => p.CodTrabajo == id);
            if (trabajo != null)
            {
                _dbContext.Trabajos.Remove(trabajo);
                _dbContext.SaveChanges();
            }
        }
    }
}
