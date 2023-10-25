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

        public Usuario GetById(int UsuarioId)
        {
            return _usuarioRepository.GetUsuarioById(UsuarioId);
        }
        
        public Usuario GetByUsername(string username)
        {
            return _usuarioRepository.GetUserByUsername(username);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAllUsuarios();
        }

        public void Add(Usuario Usuario)
        {
            _usuarioRepository.AddUsuario(Usuario);
        }

        public void Update(Usuario Usuario)
        {
            _usuarioRepository.UpdateUsuario(Usuario);
        }

        public void Delete(int UsuarioId)
        {
            var Usuario = _usuarioRepository.GetUsuarioById(UsuarioId);

            if (Usuario != null)
            {
                _usuarioRepository.DeleteUsuario(UsuarioId);
            }
        }
    }
}