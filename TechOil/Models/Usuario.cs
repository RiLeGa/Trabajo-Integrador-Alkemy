using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Usuario
    {
        [Key]
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Password { get; set; }

        public Usuario(string nombre, string password) 
        {
            Nombre = nombre;
            Password = password;
        }
    }
}
