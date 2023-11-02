using TechOil.Models;
using TechOil.Repositorys;

namespace TechOil.Services
{
    public class UsuarioService : IUsuariosService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetById(int UsuarioId)
        {
            return await _usuarioRepository.GetUsuarioById(UsuarioId);
        }
        
        public async Task<Usuario> GetByUsername(string username)
        {
            return await _usuarioRepository.GetUserByUsername(username);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _usuarioRepository.GetAllUsuarios();
        }

        public async Task Add(Usuario Usuario)
        {
            await _usuarioRepository.AddUsuario(Usuario);
        }

        public async Task Update(Usuario Usuario)
        {
            await _usuarioRepository.UpdateUsuario(Usuario);
        }

        public async Task Delete(int UsuarioId)
        {
            var Usuario = await _usuarioRepository.GetUsuarioById(UsuarioId);

            if (Usuario != null)
            {
                await _usuarioRepository.DeleteUsuario(UsuarioId);
            }
        }
    }
}