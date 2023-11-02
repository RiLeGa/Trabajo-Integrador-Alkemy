namespace TechOil.Models.Dtos
{
    public class UsuarioAuth
    {
        public string Nombre { get; set; }
        public string Password { get; set; }

        public UsuarioAuth(string nombre, string password)
        {
            Nombre = nombre;
            Password = password;
        }
    }
}
