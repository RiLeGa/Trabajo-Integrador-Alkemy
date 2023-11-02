using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TechOilF.Pages
{
    public class ServiciosModel : PageModel
    {
        public List<Servicios> Servicio { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Servicios");

                if (response.IsSuccessStatusCode)
                {
                    Servicio = await response.Content.ReadFromJsonAsync<List<Servicios>>();
                }
                else
                {
                    Servicio = new List<Servicios>();
                }
            }
        }
        public class Servicios
        {
            public int CodServicio { get; set; }
            public string Descr { get; set; }
            public Boolean Estado { get; set; }
        }
    }
}
