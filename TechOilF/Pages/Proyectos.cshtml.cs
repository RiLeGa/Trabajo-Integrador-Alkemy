using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TechOilF.Pages
{
    public class ProyectosModel : PageModel
    {
        public List<Proyectos> Proyecto { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Proyectos");

                if (response.IsSuccessStatusCode)
                {
                    Proyecto = await response.Content.ReadFromJsonAsync<List<Proyectos>>();
                }
                else
                {
                    Proyecto = new List<Proyectos>();
                }
            }
        }
        public class Proyectos
        {
            public int CodProyecto { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public int Estado { get; set; }
        }
    }
}
