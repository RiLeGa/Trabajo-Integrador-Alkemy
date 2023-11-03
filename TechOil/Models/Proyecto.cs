using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Proyecto
    {
        [Key]
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

    }
}
