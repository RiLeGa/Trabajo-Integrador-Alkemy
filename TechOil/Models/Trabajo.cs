using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Trabajo
    {
        [Key]
        public int CodTrabajo { get; set; }
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }
    }
}
