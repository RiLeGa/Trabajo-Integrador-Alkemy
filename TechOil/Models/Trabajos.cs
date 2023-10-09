namespace TechOil.Models
{
    public class Trabajos
    {
        public int CodTrabajo { get; set; }
        public DateOnly Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int ContHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }
    }
}
