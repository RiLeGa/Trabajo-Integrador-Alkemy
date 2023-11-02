using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repositorys
{
    public class ServicioRepository : IServicioRepository
    {
        public readonly TechOilDbContext _dbContext;

        public ServicioRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicios()
        {
            return await _dbContext.Servicios.ToListAsync();
        }
        public async Task<Servicio> GetServicioById(int id)
        {
            return await _dbContext.Servicios.FirstOrDefaultAsync(p => p.CodServicio == id);
        }
        public async Task AddServicio(Servicio Servicio) 
        {
            _dbContext.Servicios.Add(Servicio);
            await _dbContext.SaveChangesAsync();
        } 
        public async Task UpdateServicio(Servicio Servicio) 
        {
            _dbContext.Servicios.Update(Servicio);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteServicio(int id) 
        {
            var Servicio = _dbContext.Servicios.FirstOrDefault(p => p.CodServicio == id);
            if (Servicio != null) 
            {
                _dbContext.Servicios.Remove(Servicio);
                await _dbContext.SaveChangesAsync();
            }
        } 
    }
}
