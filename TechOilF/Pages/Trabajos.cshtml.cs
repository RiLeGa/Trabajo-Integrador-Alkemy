using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace TechOilF.Pages
{
    public class TrabajosModel : PageModel
    {
        public List<Trabajos> Trabajo { get; set; }
        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5218/api/Trabajos");

                if (response.IsSuccessStatusCode)
                {
                    Trabajo = await response.Content.ReadFromJsonAsync<List<Trabajos>>();
                }
                else
                {
                    Trabajo = new List<Trabajos>();
                }
            }
        }
        public class Trabajos
        {   
            public int CodTrabajo { get; set; }
            public int CodProyecto { get; set; }
            public int CodServicio { get; set; }
            public int CantHoras { get; set; }
        }
        public async Task<IActionResult> OnPostCrearTrabajo()
        {
            // Captura los valores de usuario y contraseña desde la solicitud POST

            string codProyectoStr = Request.Form["CodProyecto"];
            int CodProyecto = string.IsNullOrEmpty(codProyectoStr) ? 0 : int.Parse(codProyectoStr);

            string codServicioStr = Request.Form["CodServicio"];
            int CodServicio = string.IsNullOrEmpty(codServicioStr) ? 0 : int.Parse(codServicioStr);

            string cantHorasStr = Request.Form["CantHoras"];
            int CantHoras = string.IsNullOrEmpty(cantHorasStr) ? 0 : int.Parse(cantHorasStr);


            Console.WriteLine(CodProyecto + " " + CodServicio + " " + CantHoras);


            var data = new
            {   
                CodProyecto = CodProyecto,
                CodServicio = CodServicio,
                CantHoras = CantHoras
            };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.PostAsync("http://localhost:5218/api/Trabajos", content);
                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    return Page();
                }

            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync("http://localhost:5218/api/Trabajos/" + id);
                if (response.IsSuccessStatusCode)
                {
                    await OnGetAsync();
                    return Page();
                }
                else
                {
                    await OnGetAsync();
                    return Page();
                }
            }
        }
    }
}
