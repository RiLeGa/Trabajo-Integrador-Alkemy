using TechOil.Models;
using TechOil.Repositorys;

namespace TechOil.Services
{
    public class ServicioService : IServiciosService
    {

        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<Servicio> GetById(int servicioId)
        {
            return await _servicioRepository.GetServicioById(servicioId);
        }

        public async Task<IEnumerable<Servicio>> GetAll()
        {
            return await _servicioRepository.GetAllServicios();
        }

        public async Task Add(Servicio Servicio)
        {
            await _servicioRepository.AddServicio(Servicio);
        }

        public async Task Update(Servicio Servicio)
        {
            await _servicioRepository.UpdateServicio(Servicio);
        }

        public async Task Delete(int ServicioId)
        {
            var Servicio = await _servicioRepository.GetServicioById(ServicioId);

            if (Servicio != null)
            {
                await _servicioRepository.DeleteServicio(ServicioId);
            }
        }
    }
}