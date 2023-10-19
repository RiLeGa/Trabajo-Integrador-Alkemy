using Microsoft.EntityFrameworkCore;
using TechOil.Models;

namespace TechOil.DataAccess

{
    public class TechOilDbContext : DbContext
    {
        public TechOilDbContext(DbContextOptions<TechOilDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Pavi;Initial Catalog=TechOil-db;User ID=sa;Password=Root;Pooling=False;Trust Server Certificate=true");
        }
        
    }
}
