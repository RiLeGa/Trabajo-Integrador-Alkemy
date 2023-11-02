using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Trabajo>> GetAllTrabajos()
        {
            return await _dbContext.Trabajos.ToListAsync();
        }
        public async Task<Trabajo> GetTrabajoById(int id)
        {
            return await _dbContext.Trabajos.FirstOrDefaultAsync(p => p.CodTrabajo == id);
        }
        public async Task AddTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateTrabajo(Trabajo trabajo)
        {
            _dbContext.Trabajos.Update(trabajo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteTrabajo(int id)
        {
            var trabajo = _dbContext.Trabajos.FirstOrDefault(p => p.CodTrabajo == id);
            if (trabajo != null)
            {
                _dbContext.Trabajos.Remove(trabajo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
