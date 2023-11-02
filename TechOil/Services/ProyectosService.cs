using System.Runtime.CompilerServices;
using TechOil.Models;
using TechOil.Repositorys;

namespace TechOil.Services
{
    public class ProyectoService : IProyectosService
    {

        private readonly IProyectoRepository _proyectoRepository;

        public ProyectoService(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        public async Task<Proyecto> GetById(int proyectoId)
        {
            return await _proyectoRepository.GetProyectoById(proyectoId);
        }

        public async Task<IEnumerable<Proyecto>> GetAll()
        {
            return await _proyectoRepository.GetAllProyectos();
        }

        public async Task Add(Proyecto proyecto)
        {
            await _proyectoRepository.AddProyecto(proyecto);
        }

        public async Task Update(Proyecto proyecto)
        {
            await _proyectoRepository.UpdateProyecto(proyecto);
        }

        public async Task Delete(int proyectoId)
        {
            var proyecto = _proyectoRepository.GetProyectoById(proyectoId);

            if (proyecto != null)
            {
               await _proyectoRepository.DeleteProyecto(proyectoId);
            }
        }
    }
}