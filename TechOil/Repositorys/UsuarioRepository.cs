using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly TechOilDbContext _dbContext;

        public UsuarioRepository(TechOilDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _dbContext.Usuarios.ToList();
        }
        public Usuario GetUsuarioById(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(p => p.CodUsuario == id);
        }
        public void AddUsuario(Usuario usuario)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.Password, salt);

            usuario.Password = hashedPassword;

            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }
        public void UpdateUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            _dbContext.SaveChanges();
        }
        public void DeleteUsuario(int id)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(p => p.CodUsuario == id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                _dbContext.SaveChanges();
            }
        }
        public Usuario GetUserByUsername(string username)
        {
            return _dbContext.Usuarios.FirstOrDefault(u => u.Nombre == username);
        }
    }
}
