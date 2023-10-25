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

        public Proyecto GetById(int proyectoId)
        {
            return _proyectoRepository.GetProyectoById(proyectoId);
        }

        public IEnumerable<Proyecto> GetAll()
        {
            return _proyectoRepository.GetAllProyectos();
        }

        public void Add(Proyecto proyecto)
        {
            _proyectoRepository.AddProyecto(proyecto);
        }

        public void Update(Proyecto proyecto)
        {
            _proyectoRepository.UpdateProyecto(proyecto);
        }

        public void Delete(int proyectoId)
        {
            var proyecto = _proyectoRepository.GetProyectoById(proyectoId);

            if (proyecto != null)
            {
                _proyectoRepository.DeleteProyecto(proyectoId);
            }
        }
    }
}