using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Servicio
    {
        [Key]
        public int CodServicios { get; set; }
        public string Descr { get; set; }
        public Boolean Estado { get; set; }
        public decimal ValorHora { get; set; }
    }
}
