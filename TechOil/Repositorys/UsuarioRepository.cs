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

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(p => p.CodUsuario == id);
        }
        public async Task AddUsuario(Usuario usuario)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.Password, salt);

            usuario.Password = hashedPassword;

            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(p => p.CodUsuario == id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Usuario> GetUserByUsername(string username)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Nombre == username);
        }
    }
}
