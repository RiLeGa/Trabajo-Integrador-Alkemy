using TechOil.Models;
using TechOil.Repositorys;

namespace TechOil.Services
{
    public class TrabajoService : ITrabajosService
    {

        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        public async Task<Trabajo> GetById(int trabajoId)
        {
            return await _trabajoRepository.GetTrabajoById(trabajoId);
        }

        public async Task<IEnumerable<Trabajo>> GetAll()
        {
            return await _trabajoRepository.GetAllTrabajos();
        }

        public async Task Add(Trabajo trabajo)
        {
            await _trabajoRepository.AddTrabajo(trabajo);
        }

        public async Task Update(Trabajo trabajo)
        {
            await _trabajoRepository.UpdateTrabajo(trabajo);
        }

        public async Task Delete(int trabajoId)
        {
            var trabajo = await _trabajoRepository.GetTrabajoById(trabajoId);

            if (trabajo != null)
            {
                await _trabajoRepository.DeleteTrabajo(trabajoId);
            }
        }
    }
}