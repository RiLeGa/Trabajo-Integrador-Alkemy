
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Proyecto>> GetAllProyectos()
        {
            return  await _dbContext.Proyectos.ToListAsync();
        }
        public async Task<Proyecto> GetProyectoById(int id)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.CodProyecto == id);
        }
        public async Task AddProyecto(Proyecto proyecto) 
        {
            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();
        } 
        public async Task UpdateProyecto(Proyecto proyecto) 
        {
            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteProyecto(int id)
        {
            var proyecto = await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.CodProyecto == id);
            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                await _dbContext.SaveChangesAsync();
            }
           }
        } 
     
    }
